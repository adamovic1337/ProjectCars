<template>
  <section class="content">
    <div class="container-fluid text-center mb-3">
      <h1>Fuel Type Add</h1>
    </div>
    <div class="d-flex justify-content-center mt-5">
      <div class="row w-25">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header"></div>
            <div class="card-body">
              <div class="form-group">
                <label for="fuelTypeName">Fuel Type Name</label>
                <input
                  type="text"
                  id="fuelTypeName"
                  class="form-control"
                  v-model="fuelTypeData.name"
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

export default {
  data() {
    return {
      fuelTypeData: {},
    };
  },
  mounted() {},
  components: {},
  methods: {
    saveData() {
      let self = this;

      axios
        .post(`/fuelTypes`, { name: self.fuelTypeData.name })
        .then((response) => {
          toastr.success("Added new record", "Success");
        })
        .catch((error) => {
          if (error.response.status === 422) {
            let message = "";

            error.response.data.errors.forEach((e) => {
              message += `<li>${e.ErrorMessage} </li>`;
            });
            toastr.error(message, error.response.data.title);
          } else {
            toastr.error("Some error occured", "Error");
          }
        });
    },
  },
};
</script>

<style>
</style>