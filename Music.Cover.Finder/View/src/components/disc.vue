<template>
<section class="disc-container">
  <div class="card">
    <figure class="front">
      <div class="disc-container" :style="{background}">
      <div class="data">
          <div class="content">
            <h1 class="title black--text">{{artist}}</h1>
            <h1 class="title red--text">{{discTitle}}</h1>
          </div>
        </div>
      </div>
	  </figure>
    <figure class="back">
    </figure>
  </div>
</section>
</template>
<script>
const props = {
  disc: {
    required: true,
    type: Object
  }
};
export default {
  props,
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
<style <style scoped>
img {
  max-height: 150px;
  max-width: 150px;
}
.disc-container {
  margin: 10px;
  width: 150px;
  height: 150px;
}
</style>

