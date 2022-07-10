import CarDetail from '../views/Pages/Car/CarDetail.vue'
import CarAdd from '../views/Pages/Car/CarAdd.vue'

export default [  
  {
    path: '/users/:userId/cars',
    name: 'CarDetail',
    component: CarDetail,
    params: true
  },  
  {
    path: '/users/:userId/cars',
    name: 'CarAdd',
    component: CarAdd
  },
]