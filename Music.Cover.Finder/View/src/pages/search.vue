<template>
    <main>
      <v-content>
        <v-container fluid>
          <v-flex lg10 offset-lg1>
            <v-layout row wrap>
              <v-flex lg5>
                  <v-text-field box :label="$t('Resource.Album')" v-model="viewModel.Album" required></v-text-field>
                </v-flex>
                <v-flex lg5>
                  <v-text-field box :label="$t('Resource.Artist')" v-model="viewModel.Artist" required></v-text-field>
                </v-flex>
            </v-layout>
             <v-layout row wrap>
                <text-button :text="$t('Resource.Search')" :command="viewModel.Search"></text-button>
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
</style>




