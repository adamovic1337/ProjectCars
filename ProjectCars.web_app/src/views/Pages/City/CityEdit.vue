<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>City Edit</h1>
    </div>
    <div v-if="cityData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="cityId">City Id</label>
                <input
                  type="text"
                  id="cityId"
                  class="form-control"
                  :value="cityData.id"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="cityName">City Name</label>
                <input
                  type="text"
                  id="cityName"
                  class="form-control"
                  v-model="cityData.name"
                />
              </div>
              <div class="form-group">
                <label for="countyList" >Country Name</label>
                <input
                  class="form-control"
                  list="countyListOptions"
                  id="countyList"
                  placeholder="Type to search..."
                  v-model="countryName"
                  @keyup="getCountries"
                />
                <datalist id="countyListOptions">
                  <option v-for="country in countries" :key="country.id" :data-countryid="country.id" :value="country.name"></option>
                </datalist>
              </div>
              <div class="mb-4">
                <button
                  :id="cityId"
                  class="btn btn-success btn-sm w-100"
                  title="Save"
                  @click="saveData"
                >
                  <i class="fas fa-save"></i> Save
                </button>
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <router-link
                    :to="{
                      name: 'CityDetail',
                      params: { cityId: cityId },
                    }"
                    class="btn btn-info btn-sm d-block"
                    title="View"
                  >
                    <i class="fas fa-eye"></i> View
                  </router-link>
                </div>
                <div class="col-md-6">
                  <button
                    :id="cityId"
                    @click="deleteData($event)"
                    class="btn btn-danger btn-sm w-100"
                    title="Delete"
                  >
                    <i class="fas fa-trash"></i> Delete
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
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      cityId: this.$route.params.cityId,
      cityData: {},
      countryName: null,
      countries: null
    };
  },
  mounted() {
    this.getData();
  },
  components: { Preloader },
  methods: {    
    getData() {
      let self = this;
      axios
        .get(`/cities/${self.cityId}`, { headers: { 
          Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token') 
          },          
        })
        .then((response) => {
          self.cityData = response.data;
          self.countryName = response.data.countryName;
          self.getCountries();
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },    
    getCountries() {
      let self = this;

      if (self.countryName == "") {
        self.countryName = null;
      }

      axios
        .get("/countries", {
          headers: { 
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem('token') 
          },
          params: {
            countryName: self.countryName,
            orderBy: "name-asc",
            pageNumber: 1,
            pageSize: 10,
          },
        })
        .then((response) => {
          this.countries = response.data.collection;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;      
      let countryId = $('#countyListOptions [value="' + $("#countyList").val() + '"]').data('countryid');

      axios
        .put(`/cities/${self.cityId}`, { 
          name: self.cityData.name,
          countryId: countryId 
        }, 
        { 
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
          }
        })
        .then((response) => {
          toastr.success("Saved", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);
        });
    },
    deleteData(event) {
      let cityId = event.currentTarget.id;

      axios
        .delete(`/cities/${cityId}`, { headers: {
          Authorization: "Bearer " + localStorage.getItem('token')
        }
        })
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "CityList" });
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);
        });
    }
  },
};
</script>

<style>
</style>