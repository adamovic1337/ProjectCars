<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>User Profile Page</h1>
    </div>
    <div v-if="userData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="firstName">First Name</label>
                <input
                  type="text"
                  id="firstName"
                  class="form-control"
                  v-model="userData.firstName"
                />
              </div>
              <div class="form-group">
                <label for="lastName">Last Name</label>
                <input
                  type="text"
                  id="lastName"
                  class="form-control"
                  v-model="userData.lastName"
                />
              </div>
              <div class="form-group">
                <label for="username">Username</label>
                <input
                  type="text"
                  id="username"
                  class="form-control"
                  v-model="userData.username"
                />
              </div>
              <div class="form-group">
                <label for="email">Email</label>
                <input
                  type="text"
                  id="email"
                  class="form-control"
                  v-model="userData.email"
                />
              </div>
              <div class="form-group">
                <label for="password">Password</label>
                <input
                  type="password"
                  id="password"
                  class="form-control"
                  v-model="userData.password"
                />
              </div>
              <div class="form-group">
                <label for="cityList" >City Name</label>
                <input
                  class="form-control"
                  list="cityListOptions"
                  id="cityList"
                  placeholder="Type to search city..."
                  v-model="cityName"
                  @keyup="getCities"
                />
                <datalist id="cityListOptions">
                  <option v-for="city in cities" :key="city.id" :data-cityid="city.id" :value="city.name"></option>
                </datalist>
              </div>
              <div class="form-group row">
                <div class="col-md-6"> 
                    <button
                  :id="userId"
                  class="btn btn-success btn-sm w-100"
                  title="Save"
                  @click="saveData"
                >
                  <i class="fas fa-save"></i> Save
                </button>                 
                </div>                
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
      </div>
    </div>
    <div v-else>
      <Preloader />
    </div>
  </section>
  <!-- /.content -->
</template>

<script>
import Preloader from "../../../components/Preloader.vue";
import toastr from "toastr/build/toastr.min.js";
import axios from "axios";
import $ from 'jquery';
import jwt_decode from 'jwt-decode';
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      userId: 0,
      userData: {},
      responseData: {},
      cityName: null,
      cities: null
    };
  },
  mounted() {
    this.getUserId();
    this.getData();
  },
  components: { Preloader },
  methods: {
    getUserId(){
        let token = localStorage.getItem("token");
        let decoded = jwt_decode(token);
        this.userId = decoded.Id;
    },
    getData() {
      let self = this;
      axios
        .get(`/users/${self.userId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          self.userData = response.data;
          self.userData.password = null;
          self.cityName = response.data.cityName
          this.getCities();
          
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getCities(){
      let self = this;

      if (self.cityName == "") {
        self.cityName = null;
      }

      axios
        .get("/cities", {
          headers: { Accept: "application/vnd.marvin.hateoas+json", Authorization: "Bearer " + localStorage.getItem('token') },
          params: {
            cityName: self.cityName,
            orderBy: "name-asc",
            pageNumber: 1,
            pageSize: 10,
          },
        })
        .then((response) => {
          this.cities = response.data.collection;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;
      let cityId  = $('#cityListOptions [value="' + $("#cityList").val() + '"]').data('cityid');
      
      if(typeof cityId == 'undefined') {
        cityId = 0
      }

      axios
        .put(`/users/${self.userId}`, { 
            firstName: self.userData.firstName,
            lastName: self.userData.lastName,
            email: self.userData.email,
            username: self.userData.username,
            password: self.userData.password,
            roleId: self.userData.roleId,
            cityId: cityId,

        }, {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          toastr.success("Saved", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router)
        });
    }
  },
};
</script>

<style>
</style>