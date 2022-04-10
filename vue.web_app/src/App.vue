<template>
  <div class="hold-transition sidebar-mini">
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

export default {
  name: "App",
  components: {
    Navbar,
    Sidebar,
    Footer,
  },
};
</script>

<style>
</style>

<style>
.fa-arrow-circle-left, .fa-arrow-circle-right {
  cursor: pointer;
}</style>
