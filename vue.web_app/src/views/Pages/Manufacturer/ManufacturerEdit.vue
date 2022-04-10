<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Manufactrer Edit</h1>
    </div>
    <div v-if="manufacturerData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="manufacturerId">Manufacturer Id</label>
                <input
                  type="text"
                  id="manufacturerId"
                  class="form-control"
                  :value="manufacturerData.id"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="manufacturerName">Manufacturer Name</label>
                <input
                  type="text"
                  id="manufacturerName"
                  class="form-control"
                  v-model="manufacturerData.name"
                />
              </div>
              <div class="form-group">
                <label for="countryList" >Country Name</label>
                <input
                  class="form-control"
                  list="countryListOptions"
                  id="countryList"
                  placeholder="Type to search..."
                  v-model="countryName"
                  @keyup="getCountries"
                />
                <datalist id="countryListOptions">
                  <option v-for="country in countries" :key="country.id" :data-countryid="country.id" :value="country.name"></option>
                </datalist>
              </div>
              <div class="mb-4">
                <button
                  :id="manufacturerId"
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
                      name: 'ManufacturerDetail',
                      params: { manufacturerId: manufacturerId },
                    }"
                    class="btn btn-info btn-sm d-block"
                    title="View"
                  >
                    <i class="fas fa-eye"></i> View
                  </router-link>
                </div>
                <div class="col-md-6">
                  <button
                    :id="manufacturerId"
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

export default {
  data() {
    return {
      manufacturerId: this.$route.params.manufacturerId,
      manufacturerData: {},
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
        .get(`/manufacturers/${self.manufacturerId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
        })
        .then((response) => {
          self.manufacturerData = response.data;
          self.countryName = response.data.countryName;
          self.getCountries();
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },    
    getCountries() {
      let self = this;

      if (self.countryName == "") {
        self.countryName = null;
      }

      axios
        .get("/countries", {
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
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
          toastr.error("Some error occured", "Error");
        });
    },
    saveData() {
      let self = this;      
      let countryId = $('#countryListOptions [value="' + $("#countryList").val() + '"]').data('countryid');

      axios
        .put(`/manufacturers/${self.manufacturerId}`, { 
          name: self.manufacturerData.name,
          countryId: countryId 
        })
        .then((response) => {
          toastr.success("Saved", "Success");
        })
        .catch((error) => {
          if (error.response.status === 422) {
            let message = "";

            error.response.data.errors.forEach((e) => {
              message += `<li>${e.ErrorMessage} </li>`;
            });
            toastr.error(message, error.response.data.title);
          } else {
            toastr.error("Some error occured", "Error");
          }
        });
    },
    deleteData(event) {
      let manufacturerId = event.currentTarget.id;

      axios
        .delete(`/manufacturers/${manufacturerId}`)
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "ManufacturerList" });
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
  },
};
</script>

<style>
</style>