import MaintenaceList from '../views/Pages/Maintenace/MaintenanceList.vue'
import ServiceMaintenaceList from '../views/Pages/Maintenace/ServiceMaintenanceList.vue'


export default [
    {
      path: '/users/:userId/maintenances',
      name: 'MaintenaceList',
      component: MaintenaceList,
      params: true
    },
    {
      path: '/carService/:carServiceId/maintenances',
      name: 'ServiceMaintenaceList',
      component: ServiceMaintenaceList,
      params: true
    },
  ]