import FuelTypeList from '../views/Pages/FuelType/FuelTypeList.vue'
import FuelTypeDetail from '../views/Pages/FuelType/FuelTypeDetail.vue'
import FuelTypeAdd from '../views/Pages/FuelType/FuelTypeAdd.vue'
import FuelTypeEdit from '../views/Pages/FuelType/FuelTypeEdit.vue'

export default [
  {
    path: '/fuelTypes',
    name: 'FuelTypeList',
    component: FuelTypeList
  },
  {
    path: '/fuelTypes/:fuelTypeId',
    name: 'FuelTypeDetail',
    component: FuelTypeDetail,
    params: true
  },
  {
    path: '/fuelTypes',
    name: 'FuelTypeAdd',
    component: FuelTypeAdd
  },
  {
    path: '/fuelTypes/:fuelTypeId',
    name: 'FuelTypeEdit',
    component: FuelTypeEdit,
    params: true
  },
]