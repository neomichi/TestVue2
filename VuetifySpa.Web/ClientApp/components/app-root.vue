<template>
    <v-app>
        <nav-menu></nav-menu>
      
            
                    <router-view></router-view>
                   
         

    </v-app>


</template>
<script>
    import Vue from 'vue'
    import Vuetify from 'vuetify'
    import CounterExample from './counter-example'
    import FetchData from './fetch-data'
    import NavMenu from './nav-menu'
    import HomePage from './home-page'
    import Vuex from 'vuex'
    import 'vuetify/dist/vuetify.min.css'
    import 'material-design-icons-iconfont/dist/material-design-icons.scss'
    import VueProgressiveImage from 'vue-progressive-image'
    import { fail } from 'assert';

    Vue.use(Vuetify, VueProgressiveImage)
    
    Vue.component('nav-menu', NavMenu);
    //Vue.use(VeeValidate, { locale: 'ru' });
    //Validator.localize('ru', VeeValidateMessagesRu);
    Vue.component('counter-example', CounterExample);
    Vue.component('fetch-data', FetchData);
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
            title: 'Vuetify.js'

        }),

        props: {
            source: String
        },
        methods: {

        }
    }
</script>
<style>
</style>
