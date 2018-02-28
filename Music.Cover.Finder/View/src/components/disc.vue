<template>
<card :height="150" :width="150" class="disc-item" @mouseover.native="flipped=true" @mouseleave.native="flipped=false" :flipped="flipped">
	<div slot="front" class="front" :style="{background}">
	</div>
	
	<div slot="back" class="data">
		<div class="content">
			<h1 class="title black--text">{{artist}}</h1>
			<h1 class="title red--text">{{discTitle}}</h1>
		</div>
	</div>
</card>
</template>
<script>
import card from "./card";

const props = {
  disc: {
    required: true,
    type: Object
  }
};
export default {
  components: {
    card
  },
  props,
  data() {
    return {
      flipped: false
    };
  },
  methods: {
    splitTitle() {
      return this.disc.title.split(" - ");
    }
  },
  computed: {
    background() {
      return `url('${this.disc.thumb}') center/cover no-repeat`;
    },
    artist() {
      const splitted = this.splitTitle();
      return splitted[0];
    },
    discTitle() {
      const splitted = this.splitTitle();
      return splitted[1];
    }
  }
};
</script>
<style scoped>
.disc-item {
  margin: 10px;
}
.data {
  margin: 0;
  background: grey;
  width: 100%;
  height: 100%;
}
.front {
  margin: 0;
  width: 100%;
  height: 100%;
}
</style>

