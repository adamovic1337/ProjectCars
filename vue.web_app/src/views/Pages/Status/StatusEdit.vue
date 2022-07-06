<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Status Edit</h1>
    </div>
    <div v-if="statusData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="statusId">Status Id</label>
                <input
                  type="text"
                  id="statusId"
                  class="form-control"
                  :value="statusData.id"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="statusName">Status Name</label>
                <input
                  type="text"
                  id="statusName"
                  class="form-control"
                  v-model="statusData.name"
                />
              </div>
              <div class="mb-4">
                <button
                  :id="statusId"
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
                      name: 'StatusDetail',
                      params: { statusId: statusId },
                    }"
                    class="btn btn-info btn-sm d-block"
                    title="View"
                  >
                    <i class="fas fa-eye"></i> View
                  </router-link>
                </div>
                <div class="col-md-6">
                  <button
                    :id="statusId"
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
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      statusId: this.$route.params.statusId,
      statusData: {},
      responseData: {},
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
        .get(`/status/${self.statusId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json", 
          Authorization: "Bearer " + localStorage.getItem('token')
        },
        })
        .then((response) => {
          self.statusData = response.data;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;

      axios
        .put(`/status/${self.statusId}`, { name: self.statusData.name },
        {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
          }
        })
        .then((response) => {
          toastr.success("Saved", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);
        });
    },
    deleteData(event) {
      let statusId = event.currentTarget.id;

      axios
        .delete(`/status/${statusId}`, {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
          }
        })
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "StatusList" });
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