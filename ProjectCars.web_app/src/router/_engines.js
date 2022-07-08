import EngineList from '../views/Pages/Engine/EngineList.vue'
import EngineDetail from '../views/Pages/Engine/EngineDetail.vue'
import EngineAdd from '../views/Pages/Engine/EngineAdd.vue'
import EngineEdit from '../views/Pages/Engine/EngineEdit.vue'

export default [
    {
        path: '/engines',
        name: 'EngineList',
        component: EngineList
      },
      {
        path: '/engines/:engineId',
        name: 'EngineDetail',
        component: EngineDetail,
        params: true
      },
      {
        path: '/engines',
        name: 'EngineAdd',
        component: EngineAdd
      },
      {
        path: '/engines/:engineId',
        name: 'EngineEdit',
        component: EngineEdit,
        params: true
      },
]