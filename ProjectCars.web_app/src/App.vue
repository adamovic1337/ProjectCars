<template>
  <div v-if="!tokenValid && !register">    
      <div class="hold-transition login-page">
        <div class="login-box">
          <div class="card card-outline card-primary">
            <div class="card-header text-center">
              <h1 class="h1"><b>Car eBook</b></h1>
            </div>
            <div class="card-body">
              <p class="login-box-msg">Sign in to start your session</p>
              <div>
                <div class="input-group mb-3">
                  <input
                    type="email"
                    class="form-control"
                    placeholder="Email"
                    v-model="loginEmail"
                  />
                  <div class="input-group-append">
                    <div class="input-group-text">
                      <span class="fas fa-envelope"></span>
                    </div>
                  </div>
                </div>
                <div class="input-group mb-3">
                  <input
                    type="password"
                    class="form-control"
                    placeholder="Password"
                    v-model="loginPassword"
                  />
                  <div class="input-group-append">
                    <div class="input-group-text">
                      <span class="fas fa-lock"></span>
                    </div>
                  </div>
                </div>
                <button id="signin" class="btn btn-primary btn-block" @click="login">
                      Login
                </button>
              </div>
              <button id="register" class="btn btn-block btn-danger mt-4" @click="registerPage">
                      Register a new membership
              </button>
            </div>
          </div>
        </div>
      </div>    
  </div>
  <div v-else-if="register == true"> 
    <div class="hold-transition register-page">
      <div class="register-box">
        <div class="card card-outline card-primary">
          <div class="card-header text-center">
            <h1 class="h1"><b>Car eBook</b></h1>
          </div>
          <div class="card-body">
             <p class="login-box-msg">Register a new membership</p>
             <form>
                <div class="input-group mb-3">
                 <input
                   type="text"
                   class="form-control"
                   placeholder="First name"
                 />
                 <div class="input-group-append">
                   <div class="input-group-text">
                     <span class="fas fa-user"></span>
                   </div>
                 </div>
               </div>
               <div class="input-group mb-3">
                 <input
                   type="text"
                   class="form-control"
                   placeholder="Last name"
                 />
                 <div class="input-group-append">
                   <div class="input-group-text">
                     <span class="fas fa-user-friends"></span>
                   </div>
                 </div>
               </div>
               <div class="input-group mb-3">
                 <input
                   type="text"
                   class="form-control"
                   placeholder="Username"
                 />
                 <div class="input-group-append">
                   <div class="input-group-text">
                     <span class="fas fa-id-badge"></span>
                   </div>
                 </div>
               </div>
               <div class="input-group mb-3">
                 <input
                   type="email"
                   class="form-control"
                   placeholder="Email"
                 />
                 <div class="input-group-append">
                   <div class="input-group-text">
                     <span class="fas fa-envelope"></span>
                   </div>
                 </div>
               </div>
               <div class="input-group mb-3">
                 <input
                   type="password"
                   class="form-control"
                   placeholder="Password"
                 />
                 <div class="input-group-append">
                   <div class="input-group-text">
                     <span class="fas fa-lock"></span>
                   </div>
                 </div>
               </div>
               <div class="row my-4 mx-1">
                  <div class="col-6">
                      <div class="custom-control custom-radio">
                          <input type="radio" id="role" name="role" value="1" class="custom-control-input" checked>
                            <label for="role" class="custom-control-label">
                               Portal User
                            </label>
                      </div>
                  </div>
                  <div class="col-6">
                      <div class="custom-control custom-radio">
                          <input type="radio" id="serviceOwner" name="role" value="2" class="custom-control-input">
                            <label for="serviceOwner" class="custom-control-label">
                               Service Owner
                            </label>
                      </div>
                  </div>
               </div>
               <button class="btn btn-primary btn-block">
                     Register
               </button>
             </form>
             <button class="btn btn-block btn-danger mt-4"  @click="signinPage">
                     I already have a membership
             </button>
          </div>
        </div>
      </div>    
    </div>
  </div>
  <div v-else class="hold-transition sidebar-mini">
    <!-- wrapper -->
    <div class="wrapper">
      <Navbar />
      <Sidebar />

      <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <router-view />
      </div>
      <!-- /.content-wrapper -->

      <Footer />
    </div>
    <!-- ./wrapper -->
  </div>
</template>

<script>
import Navbar from "./views/Layout/Navbar.vue";
import Sidebar from "./views/Layout/Sidebar.vue";
import Footer from "./views/Layout/Footer.vue";
import axios from "axios";
import toastr from "toastr/build/toastr.min.js";
import jwt_decode from 'jwt-decode';
import {validationErrorResponse} from '../src/assets/helpers/helper';

export default {
  name: "App",
  components: {
    Navbar,
    Sidebar,
    Footer,
  },
  data() {
    return {
      tokenValid: false,
      register: false,
      loginEmail: null,
      loginPassword: null,
    };
  },
  mounted() {
      this.isTokenValid();
  },
  methods: {
    registerPage() {
      this.register = true;
    },
    signinPage() {
      this.register = false;
    },
    isTokenValid() {
      let token = null;
      token = localStorage.getItem("token");
      if(token != null) {
        let decoded = jwt_decode(token);
        if(decoded.email != null && decoded.email != "") {
          this.tokenValid = true; 
        }   
      
      }
    },
    login() {
      let self = this;

      axios
        .post(`/auth/Login`, {
          email: self.loginEmail,
          password: self.loginPassword,
        })
        .then((response) => {           
          let token = response.data.token;
          if(token != null) {
            localStorage.setItem("token", token);   
            self.isTokenValid();
          }   
          else {
            toastr.error( response.data.error, "Wrong credentials");           
          }   
        })
        .catch((error) => {
          validationErrorResponse(error, this.$router);  
        });              
    }
  }
};
</script>

<style>
  .fa-arrow-circle-left,
  .fa-arrow-circle-right {
    cursor: pointer;
  }
  .input-group-text {
    width: 40px;
  }
</style>
