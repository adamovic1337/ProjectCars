import CityList from '../views/Pages/City/CityList.vue'
import CityDetail from '../views/Pages/City/CityDetail.vue'
import CityAdd from '../views/Pages/City/CityAdd.vue'
import CityEdit from '../views/Pages/City/CityEdit.vue'

export default [
  {
    path: '/cities',
    name: 'CityList',
    component: CityList
  },
  {
    path: '/cities/:cityId',
    name: 'CityDetail',
    component: CityDetail,
    params: true
  },
  {
    path: '/cities',
    name: 'CityAdd',
    component: CityAdd
  },
  {
    path: '/cities/:cityId',
    name: 'CityEdit',
    component: CityEdit,
    params: true
  },
]