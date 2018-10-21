import store from './store'

export function AdminRules(to, from, next) {
    console.log('AdminRules');   
        if (1) {
           
            next()
            return
        } else {
        next('/login?authError=admin');  
        }
}

export function UserRules(to, from, next) {
    console.log('UserRules');
    store.dispatch('UpdateAuthUser').then(()=>{      
        console.log(store.state.authUser);
        if (1) {           
              next() 
              return
        } else {
        next('/login?authError=user');
        }
    });
}