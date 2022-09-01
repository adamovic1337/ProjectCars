<template>
  <!-- Main content -->
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>All Repairs</h1>
    </div>
    <!-- Search -->
    <div class="d-flex justify-content-center my-5">
      <div class="row d-flex justify-content-center w-50">
        <div class="col-md-5">
          <label for="dateFrom">Date From</label>
          <input
            id="dateFrom"
            class="custom-select"
            v-model="dateFrom"
            @change="getData"
            type="date"
          >
        </div>
        <div class="col-md-5">
          <label for="dateTo">Date To</label>
          <input
            id="dateTo"
            class="custom-select"
            v-model="dateTo"
            @change="getData"
            type="date"
          >
        </div>
      </div>
    </div>
    <!-- /Search -->

    <!-- Default box -->
    <div v-if="repairs != null" class="d-flex justify-content-center">
      <div class="card w-75">
        <div v-if="Object.keys(repairs).length === 0" class="card-header">
          <h2 class="text-center">There is no available data for past year.</h2> 
        </div>
        <div v-if="Object.keys(repairs).length != 0" class="card-body p-0">
          <table class="table projects">
            <thead>
                  <tr>
                    <th class="w-50">Repairs</th>
                    <th>Car Model</th>
                    <th>Repair Date</th>
                    <th>Mileage</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="r in repairs" :key="r.id" :value="r.id">
                    <td>{{r.repairs}}</td>
                    <td>{{r.modelName}}</td>
                    <td>{{r.repairDate}}</td>
                    <td>{{r.mileage}}</td>
                  </tr>
                  <tr>
                <td class="text-center font-weight-bold">
                  <label for="ddlPageSize" class="form-label">Page Size</label>
                  <select
                    @change="getData"
                    v-model="pageSize"
                    class="form-select form-select-sm w-25 mx-auto"
                    aria-label="form-select-sm example"
                    id="ddlPageSize"
                  >
                    <option selected value="10">10</option>
                    <option value="30">30</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                  </select>
                </td>
                <td class="text-center">
                  <a
                    v-if="metaData.currentPage > 1"
                    @click="previousPage"
                    class="text-secondary"
                    ><i class="fas fa-arrow-circle-left mx-2"></i
                  ></a>
                  <a
                    v-if="metaData.currentPage < metaData.totalPages"
                    @click="nextPage"
                    class="text-secondary"
                    ><i class="fas fa-arrow-circle-right mx-2"></i
                  ></a>
                </td>
                <td class="text-center font-weight-bold">
                  Page {{ metaData.currentPage }} of {{ metaData.totalPages }}
                </td>
              </tr>
                </tbody>
          </table>
        </div>
        <!-- /.card-body -->
      </div>
    </div>
    <!-- /.card -->
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
import jwt_decode from 'jwt-decode';
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      userId: 0,
      carServiceId: 0,
      dateFrom: null,
      dateTo: null,
      repairs: {},
      metaData: null,
      links: {},
      orderBy: "repairDate-desc",
      pageNumber: 1,
      pageSize: 10,

      repairName: null
    };
  },
  mounted() {
    this.getUserId();
    this.getCarServiceId();
  },
  components: { Preloader },
  methods: {
    getUserId(){
        let token = localStorage.getItem("token");
        let decoded = jwt_decode(token);
        this.userId = decoded.Id;
    },
    getCarServiceId() {
      axios
        .get(`/carServices/owner/${this.userId}`, {
          headers: {
            Accept: "application/json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          }
        })
        .then((response) => {
          this.carServiceId = response.data.id;
          this.getData();
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    nextPage() {
      let self = this;
      let next = null;

      self.links.forEach((el) => {
        if (el.rel === "next") {
          next = el.href;
        }
      });
      self.paginationData(next);
    },
    previousPage() {
      let self = this;
      let previous = null;

      self.links.forEach((el) => {
        if (el.rel === "previous") {
          previous = el.href;
        }
      });
      self.paginationData(previous);
    },
    paginationData(url) {
      axios
        .get(url, {
          headers: { 
            Accept: "application/vnd.marvin.hateoas+json", 
            Authorization: "Bearer " + localStorage.getItem('token')
          },
        })
        .then((response) => {
          this.repairs = response.data.collection;
          this.metaData = JSON.parse(response.headers["x-pagination"]);
          this.links = response.data.links;
        })
        .catch((error) => {
          unauthorized(error, this.$router); 
        });
    },
    getData() {
      let self = this;

      axios
        .get(`/carServices/${this.carServiceId}/maintenances`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token') },
          params: {
            dateFrom: self.dateFrom,
            dateTo: self.dateTo,              
            orderBy: self.orderBy,
            pageNumber: self.pageNumber,
            pageSize: self.pageSize,
          },
        })
        .then((response) => {
          self.repairs = response.data.collection;
          self.metaData = JSON.parse(response.headers["x-pagination"]);
          self.links = response.data.links;
        })
        .catch((error) => {
          unauthorized(error, this.$router);          
        });
    }
  },
};
</script>

<style>
</style>
