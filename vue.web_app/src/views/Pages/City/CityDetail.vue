<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>City Detail</h1>
    </div>
    <div v-if="cityData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-info">
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
                  :value="cityData.name"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="countryName">Country Name</label>
                <input
                  type="text"
                  id="countryName"
                  class="form-control"
                  :value="cityData.countryName"
                  disabled
                />
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <router-link
                    :to="{
                      name: 'CityEdit',
                      params: { CityId: cityId },
                    }"
                    class="btn btn-warning btn-sm d-block"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i> Edit
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
import toastr from "toastr/build/toastr.min.js";
import Preloader from "../../../components/Preloader.vue";
import axios from "axios";
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      cityId: this.$route.params.cityId,
      cityData: {},
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
        .get(`/cities/${self.cityId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token') },
        })
        .then((response) => {
          self.cityData = response.data;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    deleteData(event) {
      let cityId = event.currentTarget.id;

      axios
        .delete(`/cities/${cityId}`, { headers: { 
          Authorization: "Bearer " + localStorage.getItem('token') },
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