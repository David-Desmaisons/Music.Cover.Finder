<template>
    <main>
      <v-content>
        <v-container fluid class="main-container">
          <v-flex lg8 offset-lg2>
            <v-layout row wrap>
              <v-flex lg6>
                  <v-text-field box :label="$t('Resource.Album')" v-model="viewModel.Album" required></v-text-field>
                </v-flex>
                <v-flex lg6>
                  <v-text-field box :label="$t('Resource.Artist')" v-model="viewModel.Artist" required></v-text-field>
                </v-flex>
            </v-layout>
             <v-layout row wrap>
                <text-button :text="$t('Resource.Search')" :command="viewModel.Search" :loading="viewModel.Running" :color="blue"></text-button>
             </v-layout>

          
            <v-card wrap v-if="viewModel.Results.length>0">
              <v-toolbar color="blue">
                <v-toolbar-title>{{$t('Resource.Results')}}</v-toolbar-title>
              </v-toolbar>
              <v-list>
                <v-list-tile avatar v-for="item in viewModel.Results" :key="item.id">
                  <v-list-tile-avatar :tile="true">
                    <img :src="item.thumb"/>
                  </v-list-tile-avatar>
                  <v-list-tile-content>
                    <v-list-tile-title v-text="item.title"></v-list-tile-title>
                  </v-list-tile-content>
                </v-list-tile>
              </v-list>
            </v-card>
            <v-layout row wrap>
          </v-layout>

          </v-flex>

        </v-container>
      </v-content>
    </main>
</template>

<script>
import textButton from '../components/textButton'
import iconButton from '../components/IconButton'

const props={
  viewModel: Object,
}

export default {
  components:{
    textButton,
    iconButton
  },
  methods:{
    enter(){
      const command = this.viewModel.AddItem;
      if (command)
        command.Execute()
    }
  },
  props
}
</script>

<style>
main {
  height: 100%;
}

.main-container {
  height: 100%;
  overflow-y: auto;
}
</style>




