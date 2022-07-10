<template>
  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <router-link :to="{ name: 'Home'}">
      <h1 class="brand-link text-center">Car eBook <span class="h6 font-italic">{{portal}}</span></h1>
    </router-link>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel d-flex justify-content-center">        
          <router-link :to="{ name: 'UserEdit', params: { userId: userId } }" class="info">              
              <p><i class="far fa-user-circle"></i> {{username}}</p>
          </router-link>        
      </div>
            

      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul
          class="nav nav-pills nav-sidebar flex-column"
          data-widget="treeview"
          role="menu"
          data-accordion="false"
        >
          <!-- Add icons to the links using the .nav-icon class with font-awesome or any other icon font library -->
          <li class="nav-item">
            <router-link :to="{ name: 'RoleList' }" class="nav-link">
              <i class="nav-icon fas fa-id-card-alt"></i>
              <p>Manage Roles</p>
            </router-link>
          </li>          
          <li class="nav-item">
            <router-link :to="{ name: 'CityList' }" class="nav-link">
              <i class="nav-icon fas fa-city"></i>
              <p>Manage Cities</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'CountryList' }" class="nav-link">
              <i class="nav-icon fas fa-globe-europe"></i>
              <p>Manage Countries</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'EngineList' }" class="nav-link">
              <i class="nav-icon fas fa-tachometer-alt"></i>
              <p>Manage Engines</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'FuelTypeList' }" class="nav-link">
              <i class="nav-icon fas fa-gas-pump"></i>
              <p>Manage Fuel Types</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'ManufacturerList' }" class="nav-link">
              <i class="nav-icon fas fa-industry"></i>
              <p>Manage Manufacturers</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'CarModelList' }" class="nav-link">
              <i class="nav-icon fas fa-car-side"></i>
              <p>Manage Car Models</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'StatusList' }" class="nav-link">
              <i class="nav-icon fas fa-spinner"></i>
              <p>Manage Repair Status</p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link :to="{ name: 'CarDetail', params: { userId: userId } }" class="nav-link">
              <i class="nav-icon fas fa-car"></i>
              <p>Cars</p>
            </router-link>
          </li>
          <li class="nav-item">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-wrench"></i>
              <p>Service Requests</p>
            </a>
          </li>
          <li class="nav-item">
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-tasks"></i>
              <p>Repairs</p>
            </a>
          </li>
        </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
</template>

<script>
import jwt_decode from 'jwt-decode';

export default {
  data() {
    return {
      username: null,
      userId: 0,
      portal: null
    }
  },
  mounted() {
      let token = localStorage.getItem("token");
      let decoded = jwt_decode(token);
      this.userId = decoded.Id;
      this.username = decoded.unique_name;  
      

      switch (decoded.role){
        case 'Admin':
          this.portal = 'admin portal';
          break;
        case 'User':
          this.portal = 'user portal';
          break;
        case 'ServiceOwner':
          this.portal = 'service portal';
          break;    
      } 
      
  },
};
</script>

<style>
</style>