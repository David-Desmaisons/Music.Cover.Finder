<template>
    <main>
        <v-content>
            <v-flex xs12 sm6 offset-sm3>
            <v-card>
                <v-card-title primary-title>
                <div>
                    <h3 class="headline mb-0 blue--text">{{viewModel.Information.Name}}</h3>
                    <h3 class="headline mb-1 red--text">v {{viewModel.Information.Version}}</h3>
                    <div v-html="completeDescription"></div>
                </div>
                </v-card-title>
                <v-card-actions>
                    <!-- <v-btn flat color="orange" href="https://vuejs.org" target="_blank">Vue.js</v-btn>
                    <v-btn flat color="orange" href="https://vuetifyjs.com/" target="_blank">Vuetify</v-btn>
                    <v-btn flat color="orange" href="https://github.com/NeutroniumCore/Neutronium/" target="_blank">Neutronium</v-btn>-->
                </v-card-actions>
            </v-card>
            </v-flex>
        </v-content>
    </main>
</template>

<script>
const props={
  viewModel: Object,
}

export default {
  props,
  computed:{
      completeDescription(){
          return this.viewModel.Descriptions.join('<br>')
      }
  }
}
</script>

<style>

</style>
