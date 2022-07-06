<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Engine Add</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="engineName">Engine Name</label>
                <input
                  type="text"
                  id="engineName"
                  class="form-control"
                  v-model="engineData.name"
                />                
              </div>
              <div class="form-group">
                <label for="cubicCapacity">Cubic Capacity</label>
                <input
                  type="number"
                  id="cubicCapacity"
                  class="form-control"
                  v-model="engineData.cubicCapacity"
                />                
              </div>
              <div class="form-group">
                <label for="power">Power (HP)</label>
                <input
                  type="number"
                  id="power"
                  class="form-control"
                  v-model="engineData.power"
                />                
              </div>
              <div class="form-group">
                <label for="fuelTypeList" >Fuel Type</label>
                <input
                  class="form-control"
                  list="fuelTypeListOptions"
                  id="fuelTypeList"
                  placeholder="Type to search..."
                  v-model="fuelTypeName"
                  @keyup="getFuelTypes"
                />
                <datalist id="fuelTypeListOptions">
                  <option v-for="fuelType in fuelTypes" :key="fuelType.id" :data-fueltypeid="fuelType.id" :value="fuelType.name"></option>
                </datalist>
              </div>
              <div class="mb-4">
                <button
                  :id="engineId"
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
      engineId: this.$route.params.engineId,
      engineData: {},
      fuelTypeName: null,
      fuelTypes: null
    };
  },
  mounted() {

  },
  components: {},
  methods: {
    saveData() {
      let self = this;
      let fuelTypeId = $('#fuelTypeListOptions [value="' + $("#fuelTypeList").val() + '"]').data('fueltypeid');

      axios
        .post("/engines", { 
          name: self.engineData.name,
          fuelTypeId: fuelTypeId,
          cubicCapacity: self.engineData.cubicCapacity,
          power: self.engineData.power,
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
    getFuelTypes() {
      let self = this;

      if (self.fuelTypeName == "") {
        self.fuelTypeName = null;
      }

      axios
        .get("/fuelTypes", {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token')
          },
          params: {
            fuelTypeName: self.fuelTypeName,
            orderBy: "name-asc",
            pageNumber: 1,
            pageSize: 10,
          },
        })
        .then((response) => {
          this.fuelTypes = response.data.collection;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },    
  },
};
</script>

<style>
</style>