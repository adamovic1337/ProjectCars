<template>
  <section class="content">
    <div class="d-flex justify-content-center ">
      <div class="row w-50">
        <div class="col-md-12">
          <div class="card card-info text-center mt-5">
            <div class="card-header">
              <h1>Welcome <b>{{username}}</b>!</h1> 
            </div>
            <div class="card-body">
               <img src="../../assets/img/home.jpg" width="650" alt="home img">
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
import jwt_decode from 'jwt-decode';

export default {
  data() {
    return {
      username: null,
    };
  },
  mounted() {
      let token = localStorage.getItem("token");
      let decoded = jwt_decode(token);
      this.userId = decoded.Id;
      this.username = decoded.unique_name;        
  }    
};
</script>

<style>
</style>