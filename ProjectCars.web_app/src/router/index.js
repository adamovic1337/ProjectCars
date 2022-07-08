import { createRouter, createWebHistory } from 'vue-router'

import base from './_base'
import countries from './_countries'
import roles from './_roles'
import cities from './_cities'
import fuelTypes from './_fuelTypes'
import status from './_status'
import manufacturers from './_manufacturers'
import engines from './_engines'
import carModels from './_carModel'

const allRoutes = [];
const routes = allRoutes.concat(
                          base, 
                          countries, 
                          roles,
                          cities,
                          fuelTypes,
                          status,
                          manufacturers,
                          engines,
                          carModels
                        );


const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
