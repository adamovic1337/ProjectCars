<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Car Model Detail</h1>
    </div>
    <div v-if="carModelData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-info">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="carModelId">Car Model Id</label>
                <input
                  type="text"
                  id="carModelId"
                  class="form-control"
                  :value="carModelData.id"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="carModelName">Car Model Name</label>
                <input
                  type="text"
                  id="carModelName"
                  class="form-control"
                  :value="carModelData.name"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="carModelName">Manufacturer</label>
                <input
                  type="text"
                  id="carModelName"
                  class="form-control"
                  :value="carModelData.manufacturerName"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="carModelName">Engine</label>
                <input
                  type="text"
                  id="carModelName"
                  class="form-control"
                  :value="carModelData.engineName"
                  disabled
                />
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <router-link
                    :to="{
                      name: 'CarModelEdit',
                      params: { CarModelId: carModelId },
                    }"
                    class="btn btn-warning btn-sm d-block"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i> Edit
                  </router-link>
                </div>
                <div class="col-md-6">
                  <button
                    :id="carModelId"
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
      carModelId: this.$route.params.carModelId,
      carModelData: {},
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
        .get(`/carModels/${self.carModelId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
        })
        .then((response) => {
          self.carModelData = response.data;
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    deleteData(event) {
      let carModelId = event.currentTarget.id;

      axios
        .delete(`/carModels/${carModelId}`)
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "CarModelList" });
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