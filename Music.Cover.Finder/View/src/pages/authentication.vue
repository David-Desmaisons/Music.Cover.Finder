<template>
    <main>
        <v-dialog v-model="showModal" :persistent="false" max-width="500">
            <v-card>
                <v-card-title class="headline">{{$t('Resource.HowToDiscogsToken')}}</v-card-title>
                <v-card-text>
                <p>Go to <a @click.stop.prevent="execute(viewModel.GoToDiscogs)" href="#">https://www.discogs.com</a> to create a user.</p>
                <p>Then go to <a @click.stop.prevent="execute(viewModel.GoToToken)" href="#">https://www.discogs.com/settings/developers</a> to generate a token using <span class="blue--text">Generate new token</span> button.</p>
                </v-card-text>
                <v-card-actions>
                <v-spacer></v-spacer>
                    <text-button :text="$t('Resource.VisitDiscogs')" color="warning" :command="viewModel.GoToDiscogs"></text-button>
                    <v-btn color="primary" @click.stop="showModal=false">{{$t('Resource.Ok')}}</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>

        <v-content>

            <v-container grid-list-xl>
                <v-layout row wrap>
                    <v-flex xs10 offset-xs1>
                        <p>Please enter your discogs Token:</p>

                        <v-text-field label="Token" v-model="viewModel.Token" required>
                        </v-text-field>

                        <v-btn color="warning" @click.stop="showModal=true">{{$t('Resource.HowToDiscogsToken')}}
                        </v-btn>

                        <text-button :text="$t('Resource.SearchMusicCover')" :command="viewModel.GoToSearch">
                        </text-button>

                    </v-flex>

                </v-layout>
            </v-container>
        </v-content>
    </main>
</template>

<script>
import textButton from '../components/textButton'


const props={
  viewModel: Object,
}

export default {
    data(){
        return {
            showModal:false
        };
    },
    methods:{
        execute(command){
            !!command && command.Execute()
        }
    },
    components:{
        textButton
    },
    props
}
</script>

<style>
</style>
