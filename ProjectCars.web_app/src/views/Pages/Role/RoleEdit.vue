<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Role Edit</h1>
    </div>
    <div v-if="roleData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="roleId">Role Id</label>
                <input
                  type="text"
                  id="roleId"
                  class="form-control"
                  :value="roleData.id"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="roleName">Role Name</label>
                <input
                  type="text"
                  id="roleName"
                  class="form-control"
                  v-model="roleData.name"
                />
              </div>
              <div class="mb-4">
                <button
                  :id="roleId"
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
                      name: 'RoleDetail',
                      params: { roleId: roleId },
                    }"
                    class="btn btn-info btn-sm d-block"
                    title="View"
                  >
                    <i class="fas fa-eye"></i> View
                  </router-link>
                </div>
                <div class="col-md-6">
                  <button
                    :id="roleId"
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
      roleId: this.$route.params.roleId,
      roleData: {},
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
        .get(`/roles/${self.roleId}`, {
          headers: { Accept: "application/vnd.marvin.hateoas+json",
          Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          self.roleData = response.data;
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;

      axios
        .put(`/roles/${self.roleId}`, { name: self.roleData.name }, {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          toastr.success("Saved", "Success");
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router)
        });
    },
    deleteData(event) {
      let roleId = event.currentTarget.id;

      axios
        .delete(`/roles/${roleId}`,{
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "RoleList" });
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);
        });
    }
  },
};
</script>

<style>
</style>