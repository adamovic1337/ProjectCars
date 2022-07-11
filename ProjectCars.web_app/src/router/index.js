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
import users from './_users'
import cars from './_cars'
import maintenaces from './_maintenace'
import carService from './_carService'
import serviceRequest from './_serviceRequest'

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
                          carModels,
                          users,
                          cars,
                          maintenaces,
                          carService,
                          serviceRequest
                        );


const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
