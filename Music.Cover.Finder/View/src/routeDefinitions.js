import about from './pages/about.vue'
import search from './pages/search.vue'
import authentication from './pages/authentication.vue'

const routeDefinitions = [
    {name:'search', component: search, menu: {icon: 'search'}},
    {name:'authentication', component: authentication, menu: {icon: 'person'}},
    {name:'about', component: about,  menu: {icon: 'info'}}
]

export default routeDefinitions