<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>My Garage</h1>
    </div>
    <div v-if="cars != null" class="mt-5">
      <div class="row">
        <div class="col-md-6">
          <div class="card">
            <div class="card-header border-0">
              <h3 class="text-center">Cars Information</h3>
            </div>
            <div class="card-body">
              <div class="form-group row">
                <div class="col-md-6">
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
                <div class="col-md-6">
                  <div class="d-flex justify-content-center mt-4 pt-2">                    
                    <div class="col-md-6">
                      <router-link
                        :to="{
                          name: 'CarAdd',
                          params: { userId: userId },
                        }"
                        class="btn btn-info btn-sm d-block"
                        title="View"
                      >
                        <i class="fas fa-plus"></i> Add New Car
                      </router-link>
                    </div>
                  </div> 
                </div>
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <label for="vin">VIN</label>
                  <input
                    type="text"
                    id="vin"
                    class="form-control"
                    :value="carData.vin"
                    disabled
                  />
                </div>
                <div class="col-md-6">
                  <label for="firstRegistration">First Registration</label>
                  <input
                    type="date"
                    id="firstRegistration"
                    class="form-control"
                    :value="carData.firstRegistration"
                    disabled
                  />
                </div>
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <label for="manufacturer">Manufacturer</label>
                  <input
                    type="text"
                    id="manufacturer"
                    class="form-control"
                    :value="carData.manufacturerName"
                    disabled
                  />
                </div>
                <div class="col-md-6">
                  <label for="modelName">Model</label>
                  <input
                    type="text"
                    id="modelName"
                    class="form-control"
                    :value="carData.modelName"
                    disabled
                  />
                </div>
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <label for="engineName">Engine</label>
                  <input
                    type="text"
                    id="engineName"
                    class="form-control"
                    :value="carData.engineName"
                    disabled
                  />
                </div>
                <div class="col-md-6">
                  <label for="cubicCapacity">Cubic Capacity</label>
                  <input
                    type="text"
                    id="cubicCapacity"
                    class="form-control"
                    :value="carData.cubicCapacity"
                    disabled
                  />
                </div>
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <label for="firstName">Power (HP)</label>
                  <input
                    type="text"
                    id="firstName"
                    class="form-control"
                    :value="carData.cubicCapacity"
                    disabled
                  />
                </div>
                <div class="col-md-6">
                  <label for="fuelType">Fuel Type</label>
                  <input
                    type="text"
                    id="fuelType"
                    class="form-control"
                    :value="carData.fuelTypeName"
                    disabled
                  />
                </div>
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <label for="mileage">Mileage</label>
                  <input
                    type="text"
                    id="mileage"
                    class="form-control"
                    :value="carData.mileage"
                    disabled
                  />
                </div>
                <div class="col-md-6">  
                                 
                </div>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <div class="col-md-6">
          <div class="card">
            <div class="card-header border-0">
              <h3 class="text-center">Last 10 Repairs</h3>
            </div>
            <div class="card-body table-responsive p-0">
              <table class="table table-striped table-valign-middle">
                <thead>
                  <tr>
                    <th class="w-25">Repairs</th>
                    <th class="w-25">Car Service</th>
                    <th class="w-25">Repair Date</th>
                    <th class="w-25">Mileage</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="r in repairs" :key="r.id" :value="r.id">
                    <td class="w-25">{{r.repairs}}</td>
                    <td class="w-25">{{r.carServiceName}}</td>
                    <td class="w-25">{{r.repairDate}}</td>
                    <td class="w-25">{{r.mileage}}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <!-- /.card -->
        </div>
      </div>
    </div>
    <div v-else>
      <Preloader />
    </div>
  </section>
</template>

<script>
import Preloader from "../../../components/Preloader.vue";
import axios from "axios";
import jwt_decode from 'jwt-decode';
import { unauthorized, validationErrorResponse } from "../../../assets/helpers/helper";

export default {
  data() {
    return {
      userId: 0,
      cars: null,
      carData: {},
      selectedCar: null,
      repairs: null,
    };
  },
  mounted() {
    this.getUserId();
    this.getCars();
  },
  components: { Preloader },
  methods: {
    getUserId(){
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
          if(Object.keys(self.cars).length != 0){
            self.selectedCar = response.data.collection[0].id;
            this.getData();
          }
        })
        .catch((error) => {
          console.log(error)
          unauthorized(error, this.$router);
        });
    },
    getData() {
      let self = this;
      axios
        .get(`/users/${self.userId}/cars/${self.selectedCar}`, {
          headers: {
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
        })
        .then((response) => {
          self.carData = response.data;
          this.getRepairs();
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getRepairs() {
      let self = this;
      axios
        .get(`/users/${self.userId}/cars/${self.selectedCar}/maintenances`, 
        {
          headers: {
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          params: {
            orderBy: "repairDate-desc",
            pageSize: 10,
          },
        })
        .then((response) => {
          self.repairs = response.data.collection;
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
