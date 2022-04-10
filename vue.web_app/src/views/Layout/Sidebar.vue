<template>
  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <router-link :to="{ name: 'Home' }" class="nav-link">
      <span class="brand-link text-center">Car eBook</span>
    </router-link>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 d-flex justify-content-center">
        <div class="info">
          <a href="#" class="d-block"
            ><i class="far fa-user-circle"></i> Alexander Pierce</a
          >
        </div>
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
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-car"></i>
              <p>Cars</p>
            </a>
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
export default {};
</script>

<style>
</style>