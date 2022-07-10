import UserEdit from '../views/Pages/User/UserEdit.vue'

export default [  
  {
    path: '/users/:userId',
    name: 'UserEdit',
    component: UserEdit,
    params: true
  },
]