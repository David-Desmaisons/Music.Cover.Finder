<template>
    <v-btn :color="color" :disabled="!canExecute" :loading="loading"  @click.stop="execute">
        {{text}}
    </v-btn>
</template>

<script>
import mixin from 'neutronium-vue-command-mixin'

const props = {
    text:{
        type: String,
        required: true
    },
    color:{
        type: String,
        default: 'primary'
    },
    loading:{
        type: Boolean,
        default: false
    }
}

export default {
    mixins: [mixin],
    props
}
</script>

<<style>

</style>
