<template>
    <v-btn small icon :loading="loading" @click.stop="execute">
        <v-icon>{{icon}}</v-icon>
    </v-btn>
</template>

<script>
import mixin from 'neutronium-vue-simple-command-mixin'

const props = {
    icon:{
        type: String,
        required: true
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
