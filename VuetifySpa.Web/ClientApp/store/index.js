import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import { isNullOrEmpty } from "../app.js"
import { HasEmptyJson } from "../app.js"
Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'
const LOGIN_REGISTER_UPDATE_AUTH_STATUS = 'LOGIN_REGISTER_UPDATE_AUTH_STATUS'
const LOGOUT_SET_STATUS = 'LOGOUT_SET_STATUS'
const UPDATE_USER_STATUS = 'UPDATE_USER_STATUS'
const SET_LOADING = 'SET_LOADING'
const SET_ERROR = 'SET_ERROR'
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
    GetUserData: async () => {
        return await axios.get('/api/user');
    },
    IsAuth: state => {        
        return !HasEmptyJson(state.authUser);
    },
    IsAdmin: state => {
        
        return state;
    }
}


// MUTATIONS
const mutations = {
    [MAIN_SET_COUNTER](state, obj) {
        state.counter = obj.counter
    },
    [LOGIN_REGISTER_UPDATE_AUTH_STATUS](state, obj) {
        state.authUser = obj.data;
    },

    [LOGOUT_SET_STATUS](state, obj) {
        state.authUser = '';
    },
    [SET_LOADING](state, obj) {
        state.loading = obj;
    },
    [SET_ERROR](state, obj) {
        state.error = obj;
    },
    [CLEAR_ERROR](state) {
        state.error = null;
    },
    [UPDATE_USER_STATUS](state, obj) {
        state.authUser = obj.data;
    },
}

// ACTIONS
const actions = ({
    SET_LOADING({ commit }, obj) {
        commit(SET_LOADING, obj)
    },
    SET_ERROR({ commit }, obj) {
        commit(SET_ERROR, obj)
    },
    CLEAR_ERROR({ commit }) {
        commit(CLEAR_ERROR)
    },
    setCounter({ commit }, obj) {
        commit(MAIN_SET_COUNTER, obj)
    },
    async loginAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);

        try {
            const authUser = await axios.post('/api/auth', {
                email: obj.data.email,
                password: obj.data.password,
            });
            commit(SET_LOADING, false);
            commit(LOGIN_REGISTER_UPDATE_AUTH_STATUS, authUser);
        } catch (error) { 
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.response.data);
        }
    },
    async regAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.put('/api/auth', {
                email: obj.data.email,
                password: obj.data.password,
                firstName: obj.data.firstName,
                lastName: obj.data.lastName
            });
            commit(SET_LOADING, false);
            commit(LOGIN_REGISTER_UPDATE_AUTH_STATUS, authUser);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.response.data);
        }

    },
    async logOut({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.delete('/api/auth');
            commit(LOGOUT_SET_STATUS, "");
            commit(SET_LOADING, false);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.response.data);
        }
    },
    async UpdateAuth({ commit }) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.get('/api/auth')
            commit(LOGIN_REGISTER_UPDATE_AUTH_STATUS, authUser);
            commit(SET_LOADING, false);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.response.data);
        }
    },
    async UpdateUser({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {            
            const authUser = await axios.put('/api/user', {
                id: obj.data.id,
                avatarUrl: obj.data.avatarUrl,
                firstName: obj.data.firstName,
                lastName: obj.data.lastName,
                avatarImgType: obj.data.avatarImgType
            });            
            commit(UPDATE_USER_STATUS, authUser);
            commit(SET_LOADING, false);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.message);
        }
    }
})







export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters
});
