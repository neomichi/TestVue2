import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import { HasEmptyJson } from "../app.js"

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'
const LOGIN_SET_STATUS = 'LOGIN_SET_STATUS'
const REGISTER_SET_STATUS = 'REGISTER_SET_STATUS'
const LOGOUT_SET_STATUS = 'LOGOUT_SET_STATUS'
const SET_LOADING = 'SET_LOADING'
const ERROR_LOADING = 'ERROR_LOADING'
const CLEAR_ERROR = 'CLEAR_ERROR'
// STATE
const state = {
    counter: 0,
    authUser: '',
    loading: false,
    error: null,


}
// GETTERS
const getters = {
    GetUser: state => {   
        return (async () => {          
            state.authUser=await axios.get('/api/account');           
        })();        
       
    },
    getloading: state => {
        return state.loading;
    },
    getError: state => {
        return state.error;
    },
    clearError: state => {
        return state.error = null;
    }

}


// MUTATIONS
const mutations = {
    [MAIN_SET_COUNTER](state, obj) {
        state.counter = obj.counter
    },
    [LOGIN_SET_STATUS](state, obj) {
        console.log("---");
        console.log(obj);
      
        state.authUser = obj;
    },
    [REGISTER_SET_STATUS](state, obj) {
        state.authUser = obj;
    },
    [LOGOUT_SET_STATUS](state, obj) {
        state.authUser = '';
    },
    [SET_LOADING](state, obj) {
        state.loading = obj;
    },
    [ERROR_LOADING](state, obj) {
        state.error = obj;
    },
    [CLEAR_ERROR](state) {
        state.error = null;
    }


}

// ACTIONS
const actions = ({
    setLoading({ commit }, obj) {
        commit(SET_LOADING, obj)
    },
    setError({ commit }, obj) {
        commit(ERROR_LOADING, obj)
    },
    clearError({ commit }, obj) {
        commit(CLEAR_ERROR, obj)
    },

    setCounter({ commit }, obj) {
        commit(MAIN_SET_COUNTER, obj)
    },
    async loginAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {      
            console.log(0);
            let user = await axios.post('/api/account', {
                email: obj.data.email,
                password: obj.data.password,
            })
            console.log(1)
  

            commit(SET_LOADING, false);
            commit(LOGIN_SET_STATUS, user);
        } catch (error) {
            commit(SET_LOADING, false);
            commit(ERROR_LOADING, error.message);
        }
    },
    async regAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const user = await axios.put('/api/account', {
                email: obj.data.email,
                password: obj.data.password,
                firstName: obj.data.firstName,
                lastName: obj.data.lastName
            });
            commit(SET_LOADING, false);
            commit(REGISTER_SET_STATUS, user.data);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(ERROR_LOADING, error.message);
        }

    },
    async logOut({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const user = await axios.delete('/api/account')
            commit(LOGOUT_SET_STATUS, status.data);
            commit(SET_LOADING, false);
        }
        catch (error) {

            commit(SET_LOADING, false);
            commit(ERROR_LOADING, error.message);

        }
    },
})


export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters
});
