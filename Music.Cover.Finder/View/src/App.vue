<template>
  <v-app dark>

    <side-menu v-model="drawer" :items="menu">
    </side-menu>

    <top-menu v-model="drawer" :title="viewModel.ApplicationInformation.Name" :window="viewModel.Window">
    </top-menu>

    <modal v-model="modal" :viewModel="viewModel.Modal">
    </modal>

    <application-notification ref="notification" @notified="onNotified">
    </application-notification>

    <transition mode="out-in">
      <router-view :viewModel="viewModel.CurrentViewModel"></router-view>
    </transition>

  </v-app>
</template>

<script>

import sideMenu from './components/sideMenu'
import topMenu from './components/topMenu'
import modal from './components/modal'
import applicationNotification from './components/applicationNotification'
import routeDefinitions from './routeDefinitions'
import {menu} from './route'

const firstRouteDefinition = routeDefinitions[0]
const firstRoute = { name: firstRouteDefinition.name }

const props={
  viewModel: Object,
  __window__: Object
};

export default {
  components:{
      sideMenu,
      topMenu,
      modal,
      applicationNotification
  },
  name: 'app',
  props,
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      modal:false,
      menu
    }
  },
  mounted(){
      (window.location.hash=='#/') && (!!(this.$route.name) || this.$router.replace(firstRoute))
  },
  methods:{
    onNotified(notification) {
    }
  },
  watch:{
    'viewModel.Router.Route': function(name){
      if (name)
        this.$router.push({name});
    },
    'viewModel.Modal': function(value){
      this.modal = (value!= null)
    },
    'viewModel.Notification': function(value) {
      this.$refs['notification'].showMessage(value)
    }
  }
}
</script>

<style lang="stylus">
  @import './stylus/main'  
</style>
