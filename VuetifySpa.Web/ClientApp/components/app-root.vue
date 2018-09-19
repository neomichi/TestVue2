<template>
    <v-app>
        <nav-menu></nav-menu>
        <v-content>
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
                    не без помощи  <a target="_blank" href="https://vuetifyjs.com" style="color:white">Vuetify</a>   &copy;2018 — <strong> Nikolay </strong>
                </v-card-text>
            </v-card> 
        </v-footer>
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
    import Meta from 'vue-meta'
    Vue.use(Vuetify, VueProgressiveImage, Meta)

    Vue.component('nav-menu', NavMenu);
    Vue.component('home-page', HomePage);

    export default {
        data: () => ({
            metaInfo: {
                title: 'Ура работает', 
                titleTemplate: '%s - Bay!', 
                htmlAttrs: {
                    lang: 'ru',                    
                }
            },


            fixed: true,
            items: [{
                icon: 'bubble_chart',
                title: 'Inspire'
            }],
            miniVariant: false,
            right: true,
            rightDrawer: false,
            title: 'Vuetify.js'

        }),
        created: function () {
            store.dispatch('UpdateAuth');
        },
        props: {
            source: String
        },

        methods: {

        }
    }
</script>
<style>
</style>
