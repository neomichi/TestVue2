import store from './store'

export function AdminRules(to, from, next) {

    var data = store.getters.GetUserData.then((result) => {
        if (result.data.isAdminRole) {

            next()
            return
        }
        next('/login?authError=admin');
    })
}

export function UserRules(to, from, next) {
    var data = store.getters.GetUserData.then((result) => {
        if (result.data) {

            next()
            return
        }
        next('/login?authError=user');
    })
}