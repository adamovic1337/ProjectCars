import CountryList from '../views/Pages/Country/CountryList.vue'
import CountryDetail from '../views/Pages/Country/CountryDetail.vue'
import CountryAdd from '../views/Pages/Country/CountryAdd.vue'
import CountryEdit from '../views/Pages/Country/CountryEdit.vue'

export default [
    {
        path: '/countries',
        name: 'CountryList',
        component: CountryList
      },
      {
        path: '/countries/:countryId',
        name: 'CountryDetail',
        component: CountryDetail,
        params: true
      },
      {
        path: '/countries',
        name: 'CountryAdd',
        component: CountryAdd
      },
      {
        path: '/countries/:countryId',
        name: 'CountryEdit',
        component: CountryEdit,
        params: true
      },
]
