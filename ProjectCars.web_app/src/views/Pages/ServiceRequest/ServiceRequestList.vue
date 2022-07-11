<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Service Requests</h1>
    </div>
    <div class="mt-5">
      <div class="row">
        <div class="col-md-3">
          <div class="card">
            <div class="card-header border-0">
              <h3 class="text-center">Make Request</h3>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="selectCar">Select Car</label>
                <select
                  id="selectCar"
                  class="custom-select"
                  v-model="selectedCar"
                  @change="getData"
                >
                  <option v-for="car in cars" :key="car.id" :value="car.id">
                    {{ car.modelName }}
                  </option>
                </select>                
              </div>
              <div class="form-group">
                <label for="userDescription">Description</label>
                <input
                  type="text"
                  id="userDescription"
                  class="form-control"
                  v-model="request.userDescription" 
                />                
              </div>
              <div class="form-group">
                <label for="carServiceList" >Car Service</label>
                <input
                  class="form-control"
                  list="carServiceListOptions"
                  id="carServiceList"
                  placeholder="Type to search..."
                  v-model="carServiceName"
                  @keyup="getCarServices"
                />
                <datalist id="carServiceListOptions">
                  <option v-for="cs in carServices" :key="cs.id" :data-carserviceid="cs.id" :value="cs.name"></option>
                </datalist>
              </div> 
              <div class="form-group">
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
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <div class="col-md-9">
          
          <div class="card">
            <div class="card-header row d-flex justify-content-center border-0">
              <h3 class="text-center">My Requests</h3>
              <div class="form-group col-md-2">
                <select
                  id="selectStatus"
                  class="custom-select"
                  v-model="selectedStatus"
                  @change="getData"
                >
                  <option v-for="s in status" :key="s.id" :value="s.id">
                    {{ s.name }}
                  </option>
                </select>                
              </div>
            </div>
            <div class="card-body table-responsive p-0">
              <table class="table table-striped table-valign-middle">
                <thead>
                  <tr>
                    <th class="w-25">Description</th>
                    <th class="w-25">Appointment</th>
                    <th class="w-25">Service Name</th>
                    <th class="w-25">Car Model</th>
                    <th class="w-25">Status</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="r in userRequests" :key="r.id" :value="r.id">
                    <td class="w-25">{{ r.userDescription }}</td>
                    <td class="w-25">{{ r.appointment }}</td>
                    <td class="w-25">{{ r.carServiceName }}</td>
                    <td class="w-25">{{ r.carModel }}</td>
                    <td class="w-25">{{ r.status }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <!-- /.card -->
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import toastr from "toastr/build/toastr.min.js";
import axios from "axios";
import jwt_decode from "jwt-decode";

import $ from 'jquery';
import {unauthorized,validationErrorResponse} from "../../../assets/helpers/helper";

export default {
  data() {
    return {
      userId: 0,
      cars: null,
      request: {},
      selectedCar: null,
      carServiceName: null,
      carServices: null,

      selectedStatus: null,
      status: null,
      userRequests: null,      
    };
  },
  mounted() {
    this.getUserId();
    this.getCars();
    this.getStatus();
  },
  components: { },
  methods: {
    getUserId() {
      let token = localStorage.getItem("token");
      let decoded = jwt_decode(token);
      this.userId = decoded.Id;
    },
    getCars() {
      let self = this;
      axios
        .get(`/users/${self.userId}/cars`, {
          headers: {
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          params: {
            orderBy: "id-asc",
          },
        })
        .then((response) => {
          self.cars = response.data.collection;
          if (Object.keys(self.cars).length != 0) {
            self.selectedCar = response.data.collection[0].id;
          }
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getStatus() {
      let self = this;
      axios
        .get(`/status/`, {
          headers: {
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          params: {
            orderBy: "id-asc",
          },
        })
        .then((response) => {
          self.status = response.data.collection;
          if (Object.keys(self.status).length != 0) {
            self.selectedStatus = response.data.collection[0].id;
            this.getData();
          }
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getData() {
      let self = this;
      axios
        .get(`/serviceRequests`, {
          headers: {
            Accept: "application/json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          params: {
            statusId: self.selectedStatus,
            userId: self.userId
          }
        })
        .then((response) => {
          self.userRequests = response.data;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getCarServices() {
      let self = this;

      if (self.carServiceName == "") {
        self.carServiceName = null;
      }

      axios
        .get("/carServices", {
          headers: { Accept: "application/vnd.marvin.hateoas+json", Authorization: "Bearer " + localStorage.getItem('token') },
          params: {
            carServiceName: self.carServiceName,
            orderBy: "name-asc",
            pageNumber: 1,
            pageSize: 10,
          },
        })
        .then((response) => {
          this.carServices = response.data.collection;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;
      let carServiceId = $('#carServiceListOptions [value="' + $("#carServiceList").val() + '"]').data('carserviceid');

      axios
        .post(`/serviceRequests`, { 
          userDescription: self.request.userDescription,
          carServiceId: carServiceId, 
          userId: self.userId,
          carId: self.selectedCar,
          statusId: 1
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
  },
};
</script>

<style>
</style>
