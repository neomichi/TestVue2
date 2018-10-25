import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import Meta from 'vue-meta'
Vue.prototype.$http = axios;

sync(store, router)

Vue.use(Meta)
Vue.use(axios)

export function HasEmptyJson(obj) {      
    return typeof (obj) == 'undefined' || Object.keys(obj).length === 0;    
}
export function isNullOrEmpty(str) {    
        return str === null || str.match(/^ *$/) !== null;
}


const app = new Vue({
    store,
    router,
    ...App

})
 
export {
    app,
    router,
    store   
}


