<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Country Detail</h1>
    </div>
    <div v-if="countryData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-info">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="countryId">Country Id</label>
                <input
                  type="text"
                  id="countryId"
                  class="form-control"
                  :value="countryData.id"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="countryName">Country Name</label>
                <input
                  type="text"
                  id="countryName"
                  class="form-control"
                  :value="countryData.name"
                  disabled
                />
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <router-link
                    :to="{
                      name: 'CountryEdit',
                      params: { countryId: countryId },
                    }"
                    class="btn btn-warning btn-sm d-block"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i> Edit
                  </router-link>
                </div>
                <div class="col-md-6">
                  <button
                    :id="countryId"
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

export default {
  data() {
    return {
      countryId: this.$route.params.countryId,
      countryData: {},
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
        .get(`/countries/${self.countryId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
        })
        .then((response) => {
          self.countryData = response.data;
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    deleteData(event) {
      let countryId = event.currentTarget.id;

      axios
        .delete(`/countries/${countryId}`)
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "CountryList" });
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