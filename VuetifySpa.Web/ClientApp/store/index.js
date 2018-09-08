import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'
const LOGIN_SET_STATUS = 'LOGIN_SET_STATUS'
const REGISTER_SET_STATUS = 'REGISTER_SET_STATUS'
const LOGOUT_SET_STATUS = 'LOGOUT_SET_STATUS'
// STATE
const state = {
    counter: 0,
    authUser: '',


}
// GETTERS
const getters = {
    GetUser: state => {
        if (!state.authUser) {
            axios.get('/api/account')
                .then((response) => {
                    state.authUser = response.data;
                });

        }
        return state.authUser;
    }
}


// MUTATIONS
const mutations = {
    [MAIN_SET_COUNTER](state, obj) {
        state.counter = obj.counter
    },
    [LOGIN_SET_STATUS](state, obj) {
        state.authUser = obj;
    },
    [REGISTER_SET_STATUS](state, obj) {
        state.authUser = obj;
    },
    [LOGOUT_SET_STATUS](state, obj) {
        state.authUser = '';
    }

}

// ACTIONS
const actions = ({
    setCounter({ commit }, obj) {
        commit(MAIN_SET_COUNTER, obj)
    },
    loginAuth({ commit }, obj) {
        axios.post('/api/account', {
            email: obj.data.email,
            password: obj.data.password,
        }).then((status) => {
            commit(LOGIN_SET_STATUS, status.data);
        }).catch((authError) => {
            
        });

    },
    regAuth({ commit }, obj) {
        axios.put('/api/account', {
            email: obj.data.email,
            password: obj.data.password,
            firstName: obj.data.firstName,
            lastName: obj.data.lastName
        }).then((status) => {
            commit(REGISTER_SET_STATUS, status.data);
        }).catch((authError) => {

        });

    },
    logOut({ commit }, obj) {
        
        axios.delete('/api/account')
            .then((status) => {                
                commit(LOGOUT_SET_STATUS, status.data);                
            }).catch((authError) => {

            });
    },
})


export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters
});
