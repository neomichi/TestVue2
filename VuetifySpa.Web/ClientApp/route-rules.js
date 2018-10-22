import store from './store'
import { HasEmptyJson } from "./app.js"


export function AdminRules(to, from, next) {
    console.log('AdminRules');
    var rule = () => store.getters.IsAdmin;
    return defaultRules(to, from, next, rule, { name: 'login', query: { access: 'admin', returnUrl: to.name } });
}

export function UserRules(to, from, next) {

    var rule = () => !HasEmptyJson(store.state.authUser);
    return defaultRules(to, from, next, rule, { name: 'login', query: { access: 'user', returnUrl: to.name } });
}

export function AuthRules(to, from, next) {
    if (HasEmptyJson(store.state.authUser)) {
        next()
    } else
        next(false)
}


//private
function defaultRules(to, from, next, rulesFunction, elseUrl) {

   
    store.dispatch('UpdateAuthUser').then(() => {
        if (rulesFunction()) {           
            return next();
        } else { 
            return next(elseUrl);
        }
    }).catch(function (err) {
        console.log(error);
        return next("/");
    });

   
}