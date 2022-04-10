<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Manufacturer Add</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
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
                <label for="countryList">Country Name</label>
                <input
                  class="form-control"
                  list="countryListOptions"
                  id="countryList"
                  placeholder="Type to search..."
                  v-model="countryName"
                  @keyup="getCountries"
                />
                <datalist id="countryListOptions">
                  <option
                    v-for="country in countries"
                    :key="country.id"
                    :data-countryid="country.id"
                    :value="country.name"
                  ></option>
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
import $ from "jquery";

export default {
  data() {
    return {
      manufacturerId: this.$route.params.manufacturerId,
      manufacturerData: {},
      countryName: null,
      countries: null,
    };
  },
  mounted() {},
  components: {},
  methods: {
    saveData() {
      let self = this;
      let countryId = $('#countryListOptions [value="' + $("#countryList").val() + '"]').data("countryid");

      axios
        .post("/manufacturers", {
          name: self.manufacturerData.name,
          countryId: countryId,
        })
        .then((response) => {
          toastr.success("Added new record", "Success");
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
  },
};
</script>

<style>
</style>