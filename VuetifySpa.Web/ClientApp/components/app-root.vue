<template>
    <v-app id="inspire">

        <nav-menu></nav-menu>
        <v-content id="main">
            <v-container fluid>
         
                <router-view></router-view>
            </v-container>
        </v-content>
        <v-footer dark
                  height="auto" style="width:100%">
            <v-card flat
                    tile
                    class="indigo lighten-1 white--text text-xs-center"
                    style="width:100%">


                <v-card-text class="white--text">
                    &copy;2018 — <strong> <a target="_blank" href="https://github.com/neomichi" style="color:white">Nikolay</a> with    <a target="_blank" href="https://vuetifyjs.com" style="color:white">Vuetify</a> </strong>

                    <router-link v-if="isAdmin" to="/admin" tag="a" style="color:wheat;font-weight: bold;"> admin </router-link>

                </v-card-text>
            </v-card>
        </v-footer>
        <template>
            <v-snackbar v-if="error" :bottom="true"
                        :multi-line="true"
                        :timeout="6000"
                        color="error"
                        v-on:input="closeError"
                        :value="true">
                {{ error }}
                <v-btn v-on:click="closeError()" flat icon color="white">
                    <v-icon>close</v-icon>
                </v-btn>
            </v-snackbar>
        </template>
    </v-app>


</template>
<script>
    import Vue from 'vue'
    import Vuetify from 'vuetify'
    import NavMenu from './nav-menu'
    import HomePage from './home-page'
    import Vuex from 'vuex'
    import store from '../store'
    import 'vuetify/dist/vuetify.min.css'
    import 'material-design-icons-iconfont/dist/material-design-icons.scss'
    import VueProgressiveImage from 'vue-progressive-image'
    import { fail } from 'assert'


    Vue.use(Vuetify, VueProgressiveImage)
    Vue.component('nav-menu', NavMenu);
    Vue.component('home-page', HomePage);

    export default {
        data: () => ({

            fixed: true,
            items: [{
                icon: 'bubble_chart',
                title: 'Inspire'
            }],
            miniVariant: false,
            right: true,
            rightDrawer: false,           

        }),
        created: () => {
            store.dispatch('UpdateAuthUser');
            store.dispatch('UpateCarList');
            store.dispatch('GetMessages');
            
        },
        props: {
            source: String
        },
        computed: {
            error() {
                cache: false;
                return this.$store.getters.GetError;
            },
            isAdmin() {
                cache: false;
                return this.$store.getters.IsAdmin;
            },
        },
        methods: {           
            closeError() {
                this.$store.dispatch('CLEAR_ERROR');
            },
        }
    }
</script>   
<style scoped>
   
</style>
