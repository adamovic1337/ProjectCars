<template>
  <!-- Main content -->
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Manage Car Models</h1>
    </div>
    <!-- Search -->
    <div class="d-flex justify-content-center my-5">
      <div class="row w-50">
        <div class="col-md-7">
          <label for="txtSearchCarModel" class="form-label">Search By Name</label>
          <input
            @keyup.enter="getData"
            type="text"
            class="form-control"
            id="txtSearchCarModel"
            placeholder="Press Enter for search"
            v-model="carModelName"
          />
        </div>
        <div class="col-md-5">
          <label for="ddlCarModelOrderBy" class="form-label">Order By</label>
          <select
            @change="getData"
            v-model="orderBy"
            id="ddlCarModelOrderBy"
            class="form-select"
          >
            <option selected value="name-asc">Name Asc</option>
            <option value="name-desc">Name Desc</option>
            <option value="id-asc">ID Asc</option>
            <option value="id-desc">ID Desc</option>
          </select>
        </div>
      </div>
    </div>
    <!-- /Search -->

    <!-- Default box -->
    <div v-if="carModels != null" class="d-flex justify-content-center">
      <div class="card w-75">
        <div v-if="Object.keys(carModels).length === 0" class="card-header">
          <router-link
            :to="{ name: 'CarModelAdd' }"
            class="btn btn-tool"
            title="Add new"
          >
            <i class="fas fa-plus"></i> Add new
          </router-link>
        </div>
        <div v-if="Object.keys(carModels).length != 0" class="card-body p-0">
          <table class="table projects">
            <thead>
              <tr>
                <th style="width: 30%" class="text-center">ID</th>
                <th style="width: 30%" class="text-center">Name</th>
                <th style="width: 30%" class="text-center">Actions</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="carModel in carModels" :key="carModel.id">
                <td class="text-center">{{ carModel.id }}</td>
                <td class="text-center">{{ carModel.name }}</td>
                <td class="project-actions text-center">
                  <router-link
                    :to="{ name: 'CarModelAdd' }"
                    class="btn btn-primary btn-sm mx-1"
                    title="Add"
                  >
                    <i class="fas fa-plus"></i>
                  </router-link>
                  <router-link
                    :to="{
                      name: 'CarModelDetail',
                      params: { carModelId: carModel.id },
                    }"
                    class="btn btn-info btn-sm mx-1"
                    title="View"
                  >
                    <i class="fas fa-eye"></i>
                  </router-link>
                  <router-link
                    :to="{
                      name: 'CarModelEdit',
                      params: { carModelId: carModel.id },
                    }"
                    class="btn btn-warning btn-sm mx-1"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i>
                  </router-link>
                  <button
                    :id="carModel.id"
                    @click="deleteData($event)"
                    class="btn btn-danger btn-sm mx-1"
                    title="Delete"
                  >
                    <i class="fas fa-trash"></i>
                  </button>
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
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      carModels: null,
      metaData: null,
      links: {},
      carModelName: null,
      orderBy: "name-asc",
      pageNumber: 1,
      pageSize: 10,
    };
  },
  mounted() {
    this.getData();
  },
  components: { Preloader },
  methods: {
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
          this.carModels = response.data.collection;
          this.metaData = JSON.parse(response.headers["x-pagination"]);
          this.links = response.data.links;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getData() {
      let self = this;

      if (self.carModelName == "") {
        self.carModelName = null;
      }

      axios
        .get("/carModels", {
          headers: { 
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem('token')
          },
          params: {
            carModelName: self.carModelName,
            orderBy: self.orderBy,
            pageNumber: self.pageNumber,
            pageSize: self.pageSize,
          },
        })
        .then((response) => {
          this.carModels = response.data.collection;
          this.metaData = JSON.parse(response.headers["x-pagination"]);
          this.links = response.data.links;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    deleteData(event) {
      let carModelId = event.currentTarget.id;

      axios
        .delete(`/carModels/${carModelId}`, {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
          }
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
