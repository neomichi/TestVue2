import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'
const LOGIN_REGISTER_UPDATE_SET_STATUS = 'LOGIN_REGISTER_UPDATE_SET_STATUS'
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
    GetAuthUser: state => state.authUser,      
    Getloading: state => state.loading,    
    GetError: state => state.error,
    ClearError: state =>state.error,   
}


// MUTATIONS
const mutations = {
    [MAIN_SET_COUNTER](state, obj) {
        state.counter = obj.counter
    },
    [LOGIN_REGISTER_UPDATE_SET_STATUS](state, obj) {
       
        state.authUser = obj.data;
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
    SET_LOADING({ commit }, obj) {
        commit(SET_LOADING, obj)
    },
    ERROR_LOADING({ commit }, obj) {
        commit(ERROR_LOADING, obj)
    },
    CLEAR_ERROR({ commit }, obj) {
        commit(CLEAR_ERROR, obj)
    },

    setCounter({ commit }, obj) {
        commit(MAIN_SET_COUNTER, obj)
    },
    async loginAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.post('/api/account', {
                email: obj.data.email,
                password: obj.data.password,
            });
            commit(SET_LOADING, false);
            commit(LOGIN_REGISTER_UPDATE_SET_STATUS, authUser);
        } catch (error) {
            commit(SET_LOADING, false);
            commit(CLEAR_ERROR, error.message);
        }
    },
    async regAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.put('/api/account', {
                email: obj.data.email,
                password: obj.data.password,
                firstName: obj.data.firstName,
                lastName: obj.data.lastName
            });
            commit(SET_LOADING, false);
            commit(LOGIN_REGISTER_UPDATE_SET_STATUS, authUser);
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
            const authUser = await axios.delete('/api/account')
            commit(LOGOUT_SET_STATUS, status.data);
            commit(SET_LOADING, false);
        }
        catch (error) {

            commit(SET_LOADING, false);
            commit(ERROR_LOADING, error.message);

        }
    },
    async UpdateAuth({ commit }) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.get('/api/account')
            console.log(authUser);
            commit(LOGIN_REGISTER_UPDATE_SET_STATUS, authUser);
            commit(SET_LOADING, false);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(ERROR_LOADING, error.message);
        }
    }
})


export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters
});
