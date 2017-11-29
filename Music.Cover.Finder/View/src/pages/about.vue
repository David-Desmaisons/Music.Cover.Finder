<template>
    <main>
        <v-content>
            <v-flex lg8  offset-lg2>
                <v-card>
                    <v-card-title primary-title>
                    <div>
                        <h3 class="headline mb-0 yellow--text">{{viewModel.Information.Name}} - v.{{viewModel.Information.Version}}</h3>
                        <div  class="blue--text" v-html="completeDescription"></div>
                    </div>
                    </v-card-title>
                    <v-card-actions>
                        <v-btn flat color="orange" @click.native.prevent="execute(viewModel.GoToProduct)">GitHub</v-btn>
                        <v-btn flat color="orange" @click.native.prevent="execute(viewModel.GoToNeutronium)">Neutronium</v-btn>
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
    methods:{
        execute(command){
            !!command && command.Execute()
        }
    },
    computed:{
        completeDescription(){
            return this.viewModel.Descriptions.join('<br>')
        }
    }
}
</script>

<style>

</style>
