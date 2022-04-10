<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Car Model Edit</h1>
    </div>
    <div v-if="carModelData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
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
                  v-model="carModelData.name"
                />
              </div>
              <div class="form-group">
                <label for="manufacturerList">Manufacturer</label>
                <input
                  class="form-control"
                  list="manufacturerListOptions"
                  id="manufacturerList"
                  placeholder="Type to search..."
                  v-model="manufacturerName"
                  @keyup="getManufacturers"
                />
                <datalist id="manufacturerListOptions">
                  <option
                    v-for="manufacturer in manufacturers"
                    :key="manufacturer.id"
                    :data-manufacturerid="manufacturer.id"
                    :value="manufacturer.name"
                  ></option>
                </datalist>
              </div>
              <div class="form-group">
                <label for="engineList">Engine</label>
                <input
                  class="form-control"
                  list="engineListOptions"
                  id="engineList"
                  placeholder="Type to search..."
                  v-model="engineName"
                  @keyup="getEngines"
                />
                <datalist id="engineListOptions">
                  <option
                    v-for="engine in engines"
                    :key="engine.id"
                    :data-engineid="engine.id"
                    :value="engine.name"
                  ></option>
                </datalist>
              </div>
              <div class="mb-4">
                <button
                  :id="carModelId"
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
                      name: 'CarModelDetail',
                      params: { carModelId: carModelId },
                    }"
                    class="btn btn-info btn-sm d-block"
                    title="View"
                  >
                    <i class="fas fa-eye"></i> View
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
import Preloader from "../../../components/Preloader.vue";
import toastr from "toastr/build/toastr.min.js";
import axios from "axios";
import $ from "jquery";

export default {
  data() {
    return {
      carModelId: this.$route.params.carModelId,
      carModelData: {},
      manufacturerName: null,
      manufacturers: null,
      engineName: null,
      engines: null,
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
          self.manufacturerName = response.data.manufacturerName;
          self.getManufacturers();
          self.engineName = response.data.engineName;
          self.getEngines();
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    getManufacturers() {
      let self = this;

      if (self.manufacturerName == "") {
        self.manufacturerName = null;
      }

      axios
        .get("/manufacturers", {
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
          params: {
            manufacturerName: self.manufacturerName,
            orderBy: "name-asc",
            pageNumber: 1,
            pageSize: 10,
          },
        })
        .then((response) => {
          this.manufacturers = response.data.collection;
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    getEngines() {
      let self = this;

      if (self.engineName == "") {
        self.engineName = null;
      }

      axios
        .get("/engines", {
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
          params: {
            engineName: self.engineName,
            orderBy: "name-asc",
            pageNumber: 1,
            pageSize: 10,
          },
        })
        .then((response) => {
          this.engines = response.data.collection;
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    saveData() {
      let self = this;
      let manufacturerId = $('#manufacturerListOptions [value="' + $("#manufacturerList").val() + '"]').data("manufacturerid");
      let engineId = $('#engineListOptions [value="' + $("#engineList").val() + '"]').data("engineid");

      axios
        .put(`/carModels/${self.carModelId}`, {
          name: self.carModelData.name,
          manufacturerId: manufacturerId,
          engineId: engineId,
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