import RoleList from '../views/Pages/Role/RoleList.vue'
import RoleDetail from '../views/Pages/Role/RoleDetail.vue'
import RoleAdd from '../views/Pages/Role/RoleAdd.vue'
import RoleEdit from '../views/Pages/Role/RoleEdit.vue'

export default [
  {
    path: '/roles',
    name: 'RoleList',
    component: RoleList
  },
  {
    path: '/roles/:roleId',
    name: 'RoleDetail',
    component: RoleDetail,
    params: true
  },
  {
    path: '/roles',
    name: 'RoleAdd',
    component: RoleAdd
  },
  {
    path: '/roles/:roleId',
    name: 'RoleEdit',
    component: RoleEdit,
    params: true
  },
]