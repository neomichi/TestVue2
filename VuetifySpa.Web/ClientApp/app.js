import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import Meta from 'vue-meta'
import VeeValidate, { Validator } from 'vee-validate'
import VeeValidateRu from "vee-validate/dist/locale/ru"

Vue.prototype.$http = axios;

sync(store, router)

Vue.use(Meta)
Vue.use(axios)

Vue.use(VeeValidateRu);
Vue.use(VeeValidate);
Validator.localize('ru', VeeValidateRu);



VeeValidateRu.messages["unique_email"] = (n) => { return "данный email занят" };
VeeValidateRu.messages["regex_email"] = (n) => { return "укажите коррентный email" };
VeeValidateRu.messages["unique_cartitle"] = (n) => { return 'указанный имя занято' };

const uniqueEmail = (value) => {
    return axios.post('/api/validate/email', { email: value }).then((response) => {
        return {
            valid: response.data,
            data: {
                message: 'not work пи '
            }
        };
    });
};
///isbad
const uniqueCarTitle = (value) => {
    return axios.post('/api/car/validate/title', { title: value }).then((response) => {
        return {
            valid: response.data,
            data: {
                message: ''
            }
        };
    });
};
Validator.extend('unique_email', {
    validate: uniqueEmail,
    getMessage: field => 'указанный email занят, укажите другой'
});
Validator.extend('regex_email', {
    getMessage: field => 'укажите корректный email',
    validate: value => {
        var emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        return emailRegex.test(value);
    }
});
Validator.extend('unique_cartitle', {
    validate: uniqueCarTitle,
    getMessage: field => 'указанное имя занято'
});

//Validator.extend('regex_password', {
//    getMessage: field => 'укажите пароль(большая маленькая буква цифра символ)',
//    validate: value => {
//        var emailRegex = /^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{5,}$/,
//        return emailRegex.test(value);
//    }
//});



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


