import Home from '../views/Pages/Home.vue'
import Contact from '../views/Pages/Contact.vue'

export default [
    {
        path: '/',
        name: 'Home',
        component: Home
      },
      {
        path: '/contact',
        name: 'Contact',
        component: Contact
      },
]