import StatusList from '../views/Pages/Status/StatusList.vue'
import StatusDetail from '../views/Pages/Status/StatusDetail.vue'
import StatusAdd from '../views/Pages/Status/StatusAdd.vue'
import StatusEdit from '../views/Pages/Status/StatusEdit.vue'

export default [
  {
    path: '/status',
    name: 'StatusList',
    component: StatusList
  },
  {
    path: '/status/:statusId',
    name: 'StatusDetail',
    component: StatusDetail,
    params: true
  },
  {
    path: '/status',
    name: 'StatusAdd',
    component: StatusAdd
  },
  {
    path: '/status/:statusId',
    name: 'StatusEdit',
    component: StatusEdit,
    params: true
  },
]