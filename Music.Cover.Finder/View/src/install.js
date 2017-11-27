
import 'material-design-icons/iconfont/material-icons.css'
import 'font-awesome/css/font-awesome.css'

import Vue_Router from 'vue-router'
import {router} from './route'
import VueI18n from 'vue-i18n'
import messages from  './message'
import Notifications from 'vue-notification'

import {
    Vuetify,
    VApp,
    VAlert,
    VCheckBox,
    VDivider,
    VNavigationDrawer,
    VFooter,
    VList,
    VBtn,
    VIcon,
    VGrid,
    VToolbar,
    VCard,
    VDialog,
    VSubheader,
    VTextField,
    transitions
  } from 'vuetify'

function install(Vue) {
    Vue.use(Vuetify, {
        components: {
          VApp,
          VAlert,
          VCheckBox,
          VDivider,
          VNavigationDrawer,
          VFooter,
          VList,
          VBtn,
          VIcon,
          VGrid,
          VToolbar,
          VCard,
          VDialog,
          VTextField,
          VSubheader,
          transitions
        }
    })

    Vue.use(Vue_Router)
    Vue.use(VueI18n)
    Vue.use(Notifications)
}

function vueInstanceOption() {
    const i18n = new VueI18n({
        locale: 'en-US', // set locale
        messages // set locale messages
    });

    //Return vue global option here, such as vue-router, vue-i18n, mix-ins, .... 
    return {
        router,
        i18n
    }
}

export {
    install,
    vueInstanceOption
} 