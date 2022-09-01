<template>
  <!-- Main content -->
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Manage Requests</h1>
    </div>
    <!-- Search -->
    <div class="d-flex justify-content-center my-5">
      <div class="row d-flex justify-content-center w-50">
        <div class="col-md-5">
          <label for="selectStatus" class="form-label">Status</label>
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
    </div>
    <!-- /Search -->

    <!-- Default box -->
    <div v-if="requests != null" class="d-flex justify-content-center">
      <div class="card w-100">
        <div v-if="Object.keys(requests).length === 0" class="card-header">
          <h3 class="text-center">There is no available data for this status.</h3>
        </div>
        <div v-if="Object.keys(requests).length != 0" class="card-body p-0">
          <table class="table projects">
            <thead>
              <tr>
                <th style="width: 16.6%" class="text-center">User Description</th>
                <th style="width: 16.6%" class="text-center">Appointment</th>
                <th style="width: 16.6%" class="text-center">Car Owner</th>
                <th style="width: 16.6%" class="text-center">Car Model</th>
                <th style="width: 16.6%" class="text-center">Status</th>
                <th style="width: 16.6%" class="text-center">Action</th>

              </tr>
            </thead>
            <tbody>
              <tr v-for="r in requests" :key="r.id">
                <td class="text-center">{{ r.userDescription }}</td>
                <td class="text-center">{{ r.appointment }}</td>
                <td class="text-center">{{ r.userFName }} {{r.userLName}}</td>
                <td class="text-center">{{ r.carModel }}</td>
                <td class="text-center">{{ r.status }}</td>
                <td class="project-actions text-center">
                  <router-link
                    v-if="r.statusId != 5"
                    :to="{
                      name: 'RequestEdit',
                      params: { requestId: r.id, carId: r.carId },
                    }"
                    class="btn btn-warning btn-sm mx-1"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i>
                  </router-link>                  
                </td>
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
                <td></td>  
                <td class="text-center">
                  <a
                    v-if="metaData.currentPage > 1"
                    @click="previousPage"
                    class="text-secondary"
                    ><i class="fas fa-arrow-circle-left mx-2"></i
                  ></a>
                </td>
                <td> 
                  <a
                    v-if="metaData.currentPage < metaData.totalPages"
                    @click="nextPage"
                    class="text-secondary"
                    ><i class="fas fa-arrow-circle-right mx-2"></i
                  ></a>
                </td>
                <td></td>
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
import {
  unauthorized,
  validationErrorResponse,
} from "../../../assets/helpers/helper";

export default {
  data() {
    return {
      userId: 0,
      carServiceId: 0,
      status: null,
      requests: null,
      metaData: null,
      links: {},
      selectedStatus: null,
      pageNumber: 1,
      pageSize: 10,
    };
  },
  mounted() {
    this.getUserId();
    this.getCarServiceId();
    this.getStatus();
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
    getStatus() {
      let self = this;
      axios
        .get(`/status`, {
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
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
        })
        .then((response) => {
          this.requests = response.data.collection;
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
        .get("/serviceRequests", {
          headers: {
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          params: {
            statusId: self.selectedStatus,
            carServiceId: self.carServiceId,
            pageNumber: self.pageNumber,
            pageSize: self.pageSize,
          },
        })
        .then((response) => {
          this.requests = response.data.collection;
          this.metaData = JSON.parse(response.headers["x-pagination"]);
          this.links = response.data.links;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    deleteData(event) {
      let roleId = event.currentTarget.id;

      axios
        .delete(`/roles/${roleId}`, {
          headers: {
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
        })
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.getData();
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
