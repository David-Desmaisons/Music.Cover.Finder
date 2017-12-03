<template>
    <main>
        <v-dialog v-model="showModal" :persistent="false" max-width="500">
            <v-card>
                <v-card-title class="headline">{{$t('Resource.HowToDiscogsToken')}}</v-card-title>
                <v-card-text>
                <p>{{$t('Resource.GoTo')}} <a @click.stop.prevent="execute(viewModel.GoToDiscogs)" href="#">https://www.discogs.com</a>{{$t('Resource.ToCreateUse')}}</p>
                <p>{{$t('Resource.ThenGoTo')}}<a @click.stop.prevent="execute(viewModel.GoToToken)" href="#">https://www.discogs.com/settings/developers</a> {{$t('Resource.GenerateTokenUsing')}} <span class="blue--text">Generate new token</span> {{$t('Resource.Button')}}</p>
                </v-card-text>
                <v-card-actions>
                <v-spacer></v-spacer>
                    <text-button :text="$t('Resource.VisitDiscogs')" color="warning" :command="viewModel.GoToDiscogs"></text-button>
                    <v-btn color="primary" @click.stop="showModal=false">{{$t('Resource.Ok')}}</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>

        <v-content>

            <v-container >
            <v-flex lg8 offset-lg2>
                <v-layout row wrap>
                    <v-flex>
                        <v-text-field box label="Discogs Token" 
                            :autofocus="autoFocus"
                            v-model="viewModel.Token"
                            :append-icon="hideToken ? 'visibility' : 'visibility_off'"
                            :append-icon-cb="() => (hideToken = !hideToken)"
                            :type="hideToken ? 'password' : 'text'"
                            required>
                        </v-text-field>
                    </v-flex>
                </v-layout>

                 <v-layout row wrap>
                    <v-btn color="warning" @click.stop="showModal=true">{{$t('Resource.HowToDiscogsToken')}}
                    </v-btn>

                    <text-button :text="$t('Resource.SearchMusicCover')" :command="viewModel.GoToSearch">
                    </text-button>
                 </v-layout>
                </v-flex>
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
            showModal:false,
            hideToken:true
        };
    },
    methods:{
        execute(command){
            !!command && command.Execute()
        }
    },
    computed:{
        autoFocus(){
            return (!this.viewModel.Token)
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
