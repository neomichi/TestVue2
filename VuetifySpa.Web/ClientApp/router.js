import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'

import VeeValidate from 'vee-validate';

import VeeValidateMessagesRu from "vee-validate/dist/locale/ru";

Vue.use(VeeValidate);
Vue.use(VueRouter);


Vue.use(VeeValidate);

let router = new VueRouter({
    mode: 'history',
    routes
})

router.beforeEach((to, from, next) => {
    console.log("route");
    if (true) {
        next()
        return
    }
    next('/login')
})

export default router 
    

