<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Status Detail</h1>
    </div>
    <div v-if="statusData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-info">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="statusId">Status Id</label>
                <input
                  type="text"
                  id="ststusId"
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
                  :value="statusData.name"
                  disabled
                />
              </div>
              <div class="form-group row">
                <div class="col-md-6">
                  <router-link
                    :to="{
                      name: 'StatusEdit',
                      params: { StatusId: statusId },
                    }"
                    class="btn btn-warning btn-sm d-block"
                    title="Edit"
                  >
                    <i class="fas fa-edit"></i> Edit
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
import toastr from "toastr/build/toastr.min.js";
import Preloader from "../../../components/Preloader.vue";
import axios from "axios";

export default {
  data() {
    return {
      statusId: this.$route.params.statusId,
      statusData: {},
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
          headers: { Accept: "application/vnd.marvin.hateoas+json" },
        })
        .then((response) => {
          self.statusData = response.data;
        })
        .catch((error) => {
          toastr.error("Some error occured", "Error");
        });
    },
    deleteData(event) {
      let statusId = event.currentTarget.id;

      axios
        .delete(`/status/${statusId}`)
        .then((response) => {
          toastr.success("Deleted", "Success");
          this.$router.push({ name: "StatusList" });
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