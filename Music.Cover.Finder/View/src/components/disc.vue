<template>
   <v-flex md2 sm3>
       <img :src="disc.thumb"/>
  </v-flex>
</template>
<script>
const props = {
  disc: {
    required: true,
    type: Object
  }
};
export default {
  props
};
</script>
<style>

</style>

