<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1 v-if="carServiceId == 0">Add New Service</h1>
      <h1 v-else>Edit Service Data</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-gray">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="serviceName">Service Name</label>
                <input
                  type="text"
                  id="serviceName"
                  class="form-control"
                  v-model="serviceData.name"
                />                
              </div>
              <div class="form-group">
                <label for="phone">Phone</label>
                <input
                  type="text"
                  id="phone"
                  class="form-control"
                  v-model="serviceData.phone"
                />                
              </div>
              <div class="form-group">
                <label for="address">Address</label>
                <input
                  type="text"
                  id="address"
                  class="form-control"
                  v-model="serviceData.address"
                />                
              </div>
              <div class="form-group">
                <label for="email">Email</label>
                <input
                  type="text"
                  id="email"
                  class="form-control"
                  v-model="serviceData.email"
                />                
              </div>
              <div class="form-group">
                <label for="website">Website</label>
                <input
                  type="text"
                  id="website"
                  class="form-control"
                  v-model="serviceData.website"
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
              <div class="mb-4">
                <button
                  v-if="carServiceId > 0"
                  class="btn btn-warning btn-sm w-100"
                  title="Save"
                  @click="saveData"
                >
                  <i class="fas fa-save"></i> Save
                </button>
                <button
                  v-else
                  class="btn btn-success btn-sm w-100"
                  title="Save"
                  @click="saveData"
                >
                  <i class="fas fa-save"></i> Save
                </button>
                
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
      </div>
    </div>
  </section>
  <!-- /.content -->
</template>

<script>
import toastr from "toastr/build/toastr.min.js";
import axios from "axios";
import $ from 'jquery';
import jwt_decode from 'jwt-decode';
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';


export default {
  data() {
    return {
      userId: 0,
      carServiceId: 0,
      role: null,  
      
      serviceData: {},
      cityName: null,
      cities: null
    };
  },
  mounted() {
    this.getUserId();
    this.getCarServiceId();
  },
  components: {},
  methods: {
    getUserId(){
        let token = localStorage.getItem("token");
        let decoded = jwt_decode(token);
        this.userId = decoded.Id;
        this.role = decoded.role;
    },
    getCarServiceId() {
      if(this.role === 'ServiceOwner' || this.role === 'Admin') {
        axios
        .get(`/carServices/owner/${this.userId}`, {
          headers: {
            Accept: "application/json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          }
        })
        .then((response) => {
          if(typeof response.data.id != 'undefined')
          {
            this.carServiceId = response.data.id;
          }   
          
          if(this.carServiceId > 0){
            this.getData();
          }
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
      }
      
    },
    getData() {
      let self = this;
      axios
        .get(`/carServices/${self.carServiceId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          self.serviceData = response.data;
          self.cityName = response.data.cityName
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
      let cityId = $('#cityListOptions [value="' + $("#cityList").val() + '"]').data('cityid');

      axios
        .post(`/carServices`, { 
          name: self.serviceData.name,
          phone: self.serviceData.phone,
          address: self.serviceData.address,
          email: self.serviceData.email,
          website: self.serviceData.website,
          cityId: cityId, 
          ownerId: self.userId, 
        }, {
          headers: { 
          Authorization: "Bearer " + localStorage.getItem('token') },
        })
        .then((response) => {
          toastr.success("Added new record", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router)
        });
    },
    updateData() {
      let self = this;
      let cityId = $('#cityListOptions [value="' + $("#cityList").val() + '"]').data('cityid');

      axios
        .put(`/carServices`, { 
          name: self.serviceData.name,
          phone: self.serviceData.phone,
          address: self.serviceData.address,
          email: self.serviceData.email,
          website: self.serviceData.website,
          cityId: cityId, 
          ownerId: self.userId, 
        }, {
          headers: { 
          Authorization: "Bearer " + localStorage.getItem('token') },
        })
        .then((response) => {
          toastr.success("Added new record", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router)
        });
    },
  },
};
</script>

<style>
</style>