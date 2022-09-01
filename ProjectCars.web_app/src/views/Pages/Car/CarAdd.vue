<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Park New Car To The Garage</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="vin">VIN</label>
                <input
                  type="number"
                  id="vin"
                  class="form-control"
                  v-model="carData.vin"
                />                
              </div>
              <div class="form-group">
                <label for="firstRegistration">First Registration</label>
                <input
                  type="date"
                  id="firstRegistration"
                  class="form-control"
                  v-model="carData.firstRegistration"
                />                
              </div>
              <div class="form-group">
                <label for="mileage">Mileage</label>
                <input
                  type="number"
                  id="mileage"
                  class="form-control"
                  v-model="carData.mileage"
                />                
              </div>
              <div class="form-group">
                <label for="manufacturerList" >Manufacturer</label>
                <input
                  class="form-control"
                  list="manufacturerListOptions"
                  id="manufacturerList"
                  placeholder="Type to search..."
                  v-model="manufacturerName"
                  @keyup="getManufacturers"
                />
                <datalist id="manufacturerListOptions">
                  <option v-for="m in manufacturers" :key="m.id" :data-manufacturerid="m.id" :value="m.name"></option>
                </datalist>
              </div>
              <div class="form-group">
                <label for="modelList" >Model</label>
                <input
                  class="form-control"
                  list="modelListOptions"
                  id="modelList"
                  placeholder="Type to search..."
                  v-model="modelName"
                  @keyup="getModels"
                />
                <datalist id="modelListOptions">
                  <option v-for="m in models" :key="m.id" :data-modelid="m.id" :value="m.name"></option>
                </datalist>
              </div>
              <div class="mb-4">
                <label class="font-italic text-danger">* data will not be able to change, check before save</label>
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
import $ from 'jquery';
import jwt_decode from 'jwt-decode';
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';


export default {
  data() {
    return {
      userId: 0,
      carData: {},
      manufacturerName: null,
      manufacturers: null,
      modelName: null,
      models: null,
    };
  },
  mounted() {
    this.getUserId();
  },
  components: {},
  methods: {
    getUserId(){
        let token = localStorage.getItem("token");
        let decoded = jwt_decode(token);
        this.userId = decoded.Id;
    },
    saveData() {
      let self = this;
      let modelId = $('#modelListOptions [value="' + $("#modelList").val() + '"]').data('modelid');

      axios
        .post(`/users/${self.userId}/cars`, { 
          vin: self.carData.vin,
          firstRegistration: self.carData.firstRegistration, 
          mileage: self.carData.mileage,
          modelId: modelId
        }, 
        {
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
    getModels() {
      let self = this;
      let manufacturerId = $('#manufacturerListOptions [value="' + $("#manufacturerList").val() + '"]').data('manufacturerid');

      if(manufacturerId != null){
        axios
        .get(`/carModels/ddl/${manufacturerId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token')
          },
        })
        .then((response) => {
          self.models = response.data;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
      }
      else{
        toastr.warning("Select manufacturer first.", "warning");
      }

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