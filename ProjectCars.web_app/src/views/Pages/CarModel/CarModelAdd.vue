<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Car Model Add</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
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
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      carModelData: {},
      manufacturerName: null,
      manufacturers: null,
      engineName: null,
      engines: null,
    };
  },
  mounted() {},
  components: {},
  methods: {
    getManufacturers() {
      let self = this;

      if (self.manufacturerName == "") {
        self.manufacturerName = null;
      }

      axios
        .get("/manufacturers", {
          headers: { 
            Accept: "application/vnd.marvin.hateoas+json", 
            Authorization: "Bearer " + localStorage.getItem('token')
          },
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
          unauthorized(error, this.$router);
        });
    },
    getEngines() {
      let self = this;

      if (self.engineName == "") {
        self.engineName = null;
      }

      axios
        .get("/engines", {
          headers: { 
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem('token')
          },
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
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;
      let manufacturerId = $('#manufacturerListOptions [value="' + $("#manufacturerList").val() + '"]').data("manufacturerid");
      let engineId = $('#engineListOptions [value="' + $("#engineList").val() + '"]').data("engineid");

      axios
        .post(`/carModels`, {
          name: self.carModelData.name,
          manufacturerId: manufacturerId,
          engineId: engineId,
        },
        {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
          }
        })
        .then((response) => {
          toastr.success("Added new record", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);
        });
    },
  },
};
</script>

<style>
</style>