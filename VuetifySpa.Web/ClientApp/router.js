﻿import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'
import { carRoutes } from './routes'
import { userRoutes } from './routes'
import { authRoutes } from './routes'
import { adminRoutes } from './routes'

let router = new VueRouter({
    mode: 'history',
    routes: routes.concat(carRoutes, userRoutes, authRoutes,adminRoutes)
})
//router.onError(error => {
   
//});

//router.beforeResolve((to, from, next) => {
 

//});

import VeeValidate from 'vee-validate';

import VeeValidateMessagesRu from "vee-validate/dist/locale/ru";

Vue.use(VueRouter);
Vue.use(VeeValidate);

export default router 
    

