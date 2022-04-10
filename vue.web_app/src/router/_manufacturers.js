import ManufacturerList from '../views/Pages/Manufacturer/ManufacturerList.vue'
import ManufacturerDetail from '../views/Pages/Manufacturer/ManufacturerDetail.vue'
import ManufacturerAdd from '../views/Pages/Manufacturer/ManufacturerAdd.vue'
import ManufacturerEdit from '../views/Pages/Manufacturer/ManufacturerEdit.vue'

export default [
  {
    path: '/manufacturers',
    name: 'ManufacturerList',
    component: ManufacturerList
  },
  {
    path: '/manufacturers/:manufacturerId',
    name: 'ManufacturerDetail',
    component: ManufacturerDetail,
    params: true
  },
  {
    path: '/manufacturers',
    name: 'ManufacturerAdd',
    component: ManufacturerAdd
  },
  {
    path: '/manufacturers/:manufacturerId',
    name: 'ManufacturerEdit',
    component: ManufacturerEdit,
    params: true
  },
]