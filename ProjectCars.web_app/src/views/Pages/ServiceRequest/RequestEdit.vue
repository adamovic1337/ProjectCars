<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Request Edit</h1>
    </div>
    <div v-if="requestData.id" class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-warning">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="userDescription">User Description</label>
                <input
                  type="text"
                  id="userDescription"
                  class="form-control"
                  :value="requestData.userDescription"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="appointment">Appointment</label>
                <input
                  type="date"
                  id="appointment"
                  class="form-control"
                  v-model="requestData.appointment"
                />
              </div>
              <div class="form-group">
                <label for="repairStart">Repair Started</label>
                <input
                  type="date"
                  id="repairStart"
                  class="form-control"
                  v-model="requestData.repairStart"
                />
              </div>
              <div class="form-group">
                <label for="repairEnd">Request Completed</label>
                <input
                  type="date"
                  id="repairEnd"
                  class="form-control"
                  v-model="requestData.repairEnd"
                />
              </div>
              <div class="form-group">
                <label for="selectStatus" class="form-label">Status</label>
                <select
                  id="selectStatus"
                  class="custom-select"
                  v-model="selectedStatus"
                >
                  <option v-for="s in status" :key="s.id" :value="s.id">
                    {{ s.name }}
                  </option>
                </select>
              </div>
              <div class="form-group">
                <label for="carModel">Car Model</label>
                <input
                  type="text"
                  id="carModel"
                  class="form-control"
                  v-model="requestData.carModel"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="carManufacturer">Car Manufacturer</label>
                <input
                  type="text"
                  id="carManufacturer"
                  class="form-control"
                  v-model="requestData.carManufacturer"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="userFName">Car Owner Name</label>
                <input
                  type="text"
                  id="userFName"
                  class="form-control"
                  v-model="requestData.userFName"
                  disabled
                />
              </div>
              <div class="form-group">
                <label for="userLName">Car Owner Last Name</label>
                <input
                  type="text"
                  id="userLName"
                  class="form-control"
                  v-model="requestData.userLName"
                  disabled
                />
              </div>
              <div class="mb-4">
                <button
                  class="btn btn-success btn-sm w-100"
                  title="Save"
                  @click="saveData"
                >
                  <i class="fas fa-save"></i> Save
                </button>
              </div>
              <div class="mb-4">
                <router-link
                    :to="{
                      name: 'MaintenaceAdd',
                      params: { carServiceId: requestData.carServiceId, carId: carId}
                    }"
                    class="btn btn-info btn-sm w-100"
                    title="Edit"
                  >
                    <i class="fas fa-plus"></i> Add Repairs
                  </router-link>
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
import {
  unauthorized,
  validationErrorResponse,
} from "../../../assets/helpers/helper";

export default {
  data() {
    return {
      carId: this.$route.params.carId,
      requestId: this.$route.params.requestId,
      requestData: {},
      status: null,
      selectedStatus: null,
    };
  },
  mounted() {
    this.getStatus();
    this.getData();
  },
  components: { Preloader },
  methods: {
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
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    getData() {
      let self = this;
      axios
        .get(`/serviceRequests/${self.requestId}`, {
          headers: {
            Accept: "application/vnd.marvin.hateoas+json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
        })
        .then((response) => {
          self.requestData = response.data;    
          self.selectedStatus = response.data.statusId
        })
        .catch((error) => {
          unauthorized(error, this.$router);
        });
    },
    saveData() {
      let self = this;

      axios
        .put(
          `/serviceRequests/${self.requestId}`,
          { 
            userDescription: self.requestData.userDescription,
            appointment: self.requestData.appointment,
            repairStart: self.requestData.repairStart,
            repairEnd: self.requestData.repairEnd,
            carServiceId: self.requestData.carServiceId,
            carId: self.requestData.carId,
            userId: self.requestData.userId,
            statusId: self.selectedStatus,
          },
          {
            headers: {
              Authorization: "Bearer " + localStorage.getItem("token"),
            },
          }
        )
        .then((response) => {
          toastr.success("Saved", "Success");
          this.sendNotification();
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);
        });
    },
    sendNotification() {
      let self = this;

      axios
        .post(
          `Notification/SendEmail`,
          { 
            UserId: self.requestData.userId,
            ServiceId: self.requestData.carServiceId,            
            StatusId: self.selectedStatus,
          },
          {
            headers: {
              Authorization: "Bearer " + localStorage.getItem("token"),
            },
          }
        )
        .then((response) => {
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