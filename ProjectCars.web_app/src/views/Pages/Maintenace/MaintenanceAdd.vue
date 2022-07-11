<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Repairs</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="repairs">Repairs</label>
                <textarea
                  id="repairs"
                  class="form-control"
                  v-model="repairData.repairs"
                ></textarea>
              </div>
              <div class="form-group">
                <label for="mileage">Mileage</label>
                <input
                  type="text"
                  id="mileage"
                  class="form-control"
                  v-model="repairData.mileage"
                >
              </div>
              <div class="form-group">
                <label for="repairDate">Repair Date</label>
                <input
                  type="date"
                  id="repairDate"
                  class="form-control"
                  v-model="repairData.repairDate"
                >
              </div>
              <div class="mb-4">
                <button
                  class="btn btn-success btn-sm w-100"
                  title="Save"
                  @click="saveData">
                  <i class="fas fa-save"></i> Save
                </button>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
      </div>
    </div>
  </section>
  <!-- /.content -->
</template>

<script>
import toastr from "toastr/build/toastr.min.js";
import axios from "axios";
import {unauthorized, validationErrorResponse} from '../../../assets/helpers/helper';

export default {
  data() {
    return {
      carId: this.$route.params.carId,
      carServiceId: this.$route.params.carServiceId,
      repairData: {},
    };
  },
  mounted() {},
  components: {},
  methods: {
    saveData() {
      let self = this;

      axios
        .post(`/carServices/${this.carServiceId}/maintenances`, 
        { 
            repairs: self.repairData.repairs, 
            mileage: self.repairData.mileage, 
            repairDate: self.repairData.repairDate, 
            carId: self.carId, 
        }, 
        {
          headers: {
            Authorization: "Bearer " + localStorage.getItem('token') 
          },
        })
        .then((response) => {
          toastr.success("Added new record", "Success");
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