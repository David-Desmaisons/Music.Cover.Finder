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
            <div class="isotope-container" v-resize:debounce.25="onResize">
              <isotope class="isotope-root" ref="isotope" :options='getIsotopeOptions()' :list="viewModel.Results">
                <disc v-for="(item,index) in viewModel.Results" :key="index" :disc="item">
                </disc>
              </isotope>
            </div>
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
import isotope from "vueisotope";
import resize from "vue-resize-directive";

const props = {
  viewModel: Object
};

export default {
  directives: {
    resize
  },
  components: {
    textButton,
    iconButton,
    disc,
    isotope
  },
  methods: {
    submit() {
      const command = this.viewModel.Search;
      if (command) command.Execute();
    },
    getIsotopeOptions() {
      return {
        masonry: {
          columnWidth: 170,
          fitWidth: true
        }
      };
    },
    onResize() {
      const isotope = this.$refs["isotope"];
      isotope && isotope.layout();
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
.isotope-container {
  width: 100%;
  display: flex;
  justify-content: center;
}
.isotope-root {
  width: 100%;
}
div::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  background-color: #000000;
}
div::-webkit-scrollbar {
  width: 8px;
  background-color: #000000;
}
div::-webkit-scrollbar-thumb {
  background-color: #f5f5f5;
}
</style>




