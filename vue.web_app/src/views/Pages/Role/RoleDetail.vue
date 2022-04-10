<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Role Detail</h1>
    </div>
    <div v-if="roleData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-info">
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
                  :value="roleData.name"
                  disabled
                />
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <router-link
                    :to="{
                      name: 'RoleEdit',
                      params: { RoleId: roleId },
                    }"
                    class="btn btn-warning btn-sm d-block"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i> Edit
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
import toastr from "toastr/build/toastr.min.js";
import Preloader from "../../../components/Preloader.vue";
import axios from "axios";

export default {
  data() {
    return {
      roleId: this.$route.params.roleId,
      roleData: {},
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
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
        })
        .then((response) => {
          self.roleData = response.data;
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    deleteData(event) {
      let roleId = event.currentTarget.id;

      axios
        .delete(`/roles/${roleId}`)
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "RoleList" });
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
  },
};
</script>

<style>
</style>