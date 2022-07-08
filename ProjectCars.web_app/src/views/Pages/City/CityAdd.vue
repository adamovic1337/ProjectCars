<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>City Add</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
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

  },
  components: {},
  methods: {
    saveData() {
      let self = this;
      let countryId = $('#countyListOptions [value="' + $("#countyList").val() + '"]').data('countryid');

      axios
        .post(`/cities`, { 
          name: self.cityData.name,
          countryId: countryId, 
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
    getCountries() {
      let self = this;

      if (self.countryName == "") {
        self.countryName = null;
      }

      axios
        .get("/countries", {
          headers: { Accept: "application/vnd.marvin.hateoas+json", Authorization: "Bearer " + localStorage.getItem('token') },
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
    }
  },
};
</script>

<style>
</style>