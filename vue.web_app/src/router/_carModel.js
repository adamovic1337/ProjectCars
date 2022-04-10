import CarModelList from '../views/Pages/CarModel/CarModelList.vue'
import CarModelDetail from '../views/Pages/CarModel/CarModelDetail.vue'
import CarModelAdd from '../views/Pages/CarModel/CarModelAdd.vue'
import CarModelEdit from '../views/Pages/CarModel/CarModelEdit.vue'

export default [
  {
    path: '/carModels',
    name: 'CarModelList',
    component: CarModelList
  },
  {
    path: '/carModels/:carModelId',
    name: 'CarModelDetail',
    component: CarModelDetail,
    params: true
  },
  {
    path: '/carModels',
    name: 'CarModelAdd',
    component: CarModelAdd
  },
  {
    path: '/carModels/:carModelId',
    name: 'CarModelEdit',
    component: CarModelEdit,
    params: true
  },
]