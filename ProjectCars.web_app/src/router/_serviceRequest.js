import ServiceRequestList from '../views/Pages/ServiceRequest/ServiceRequestList.vue'
import RequestList from '../views/Pages/ServiceRequest/RequestList.vue'
import RequestEdit from '../views/Pages/ServiceRequest/RequestEdit.vue'

export default [
  {
    path: '/serviceRequests',
    name: 'ServiceRequestList',
    component: ServiceRequestList
  },
  {
    path: '/manageServiceRequests',
    name: 'RequestList',
    component: RequestList
  },
  {
    path: '/manageServiceRequests/:requestId/car/:carId',
    name: 'RequestEdit',
    component: RequestEdit,
    params: true
  },
]