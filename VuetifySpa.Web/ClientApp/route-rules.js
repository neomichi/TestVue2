import store from './store'
import { HasEmptyJson } from "./app.js"

export function AdminRules(to, from, next) {
    console.log('AdminRules');   
        if (store.getters.IsAdmin) {
           
            next()
            return
        } else {
        next('/login?authError=admin');  
        }
}

export function UserRules(to, from, next) {   
    store.dispatch('UpdateAuthUser').then(()=>{      
        if (!HasEmptyJson(store.state.authUser)) {                  
              next() 
              return
        } else {
        next('/login?authError=user');
        }
    });
}



export function AuthRules(to, from, next) {

    store.dispatch('UpdateAuthUser').then(() => {          
        if (HasEmptyJson(store.state.authUser)) {
            next()
            return
        } else {
            next('/');
        }
    });
}