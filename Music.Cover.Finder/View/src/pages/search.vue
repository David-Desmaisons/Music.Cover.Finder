<template>
    <main>
      <v-content>
        <v-container fluid class="main-container">
          <v-flex lg10 offset-lg1>

            <v-card>
              <v-layout row wrap>
                <v-flex lg6>
                    <v-text-field box :label="$t('Resource.Album')" v-model="viewModel.Album" @keyup.enter.native="submit" required :autofocus="autoFocus"></v-text-field>
                  </v-flex>
                  <v-flex lg6>
                    <v-text-field box :label="$t('Resource.Artist')" v-model="viewModel.Artist" @keyup.enter.native="submit" required></v-text-field>
                  </v-flex>
              </v-layout>
              <v-layout row wrap>
                  <v-flex>
                    <text-button :text="$t('Resource.Search')" :command="viewModel.Search" :loading="viewModel.Running" color="blue"></text-button>
                  </v-flex>
              </v-layout>
             </v-card>
          
            <v-card wrap v-if="viewModel.Results.length>0">
              <v-toolbar color="blue">
                <v-toolbar-title>{{resultsFound}}</v-toolbar-title>
              </v-toolbar>
              <v-layout row wrap>
                  <disc v-for="(item,index) in viewModel.Results" :key="index" :disc="item">
                  </disc>
              </v-layout>
            </v-card>

            <v-card wrap v-if="viewModel.NothingFound">
              <v-toolbar color="red">
                <v-toolbar-title>{{$t('Resource.NoResultFound')}}</v-toolbar-title>
              </v-toolbar>
	          </v-card>

            <v-layout row wrap>
          </v-layout>

          </v-flex>

        </v-container>
      </v-content>
    </main>
</template>

<script>
import textButton from "../components/textButton";
import iconButton from "../components/IconButton";
import disc from "../components/disc";


const props = {
  viewModel: Object
};

export default {
  components: {
    textButton,
    iconButton,
    disc
  },
  methods: {
    submit() {
      const command = this.viewModel.Search;
      if (command) command.Execute();
    }
  },
  computed: {
    resultsFound() {
      var count = this.viewModel.Results.length;
      return count <= 1
        ? `${count} ${this.$t("Resource.ResultFound")}`
        : `${count} ${this.$t("Resource.ResultsFound")}`;
    },
    autoFocus() {
      return this.viewModel.Album == null && this.viewModel.Artist == null;
    }
  },
  props
};
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




