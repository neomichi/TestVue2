import store from './store'

export function AdminRules(to, from, next) {   
    if (store.getters.IsAdmin) {
    
        next()
        return
    }
    next('/login?authError=admin');
}

export function UserRules(to, from, next) {
    if (store.getters.IsAuth) {
        next()
        return
    }
    next('/login?authError=user');
}