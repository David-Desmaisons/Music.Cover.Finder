import Vue from 'vue'
import App from './App.vue'
import rawVm from '../data/vm'
import { install, vueInstanceOption } from './install'
import { routes } from './devRoutes'
import { createVM } from 'neutronium-vm-loader'

const vm = createVM(rawVm);
install(Vue)

var options = vueInstanceOption();
const { router } = options;
router.beforeEach((to, from, next) => {
    const name = to.name;
    if (!name) {
        next();
        return;
    }
    const nameToFind = routes[name] || "vm"
    import(`../data/${name}/${nameToFind}.cjson`).then(module => {
        const newVm = createVM(module);
        router.app.ViewModel.CurrentViewModel = newVm.ViewModel.CurrentViewModel;
        next();
    }).catch(error => {
        console.log(error)
        console.log(`Problem loading file: "${`../data/${name}/${nameToFind}.cjson`}". Please create corresponding file to be able to . ViewModel will be set to null.`)
        router.app.ViewModel.CurrentViewModel = null;
        next();
    })
})

const vueRootInstanceOption = Object.assign({}, options, {
    components: {
        App
    },
    data: vm
});
new Vue(vueRootInstanceOption).$mount('#main')
