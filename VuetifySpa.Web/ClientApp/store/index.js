import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import { HasEmptyJson } from "../app.js"


Vue.use(Vuex)

// TYPES
const LOGIN_REGISTER_UPDATE_USER_STATUS = 'LOGIN_REGISTER_UPDATE_USER_STATUS'
const LOGOUT_SET_STATUS = 'LOGOUT_SET_STATUS'
const SET_LOADING = 'SET_LOADING'
const SET_ERROR = 'SET_ERROR'
const CLEAR_ERROR = 'CLEAR_ERROR'
const UPDATE_CARS_STATUS = 'UPDATE_CARS_STATUS'
const ADD_EDIT_CAR_STATUS = 'ADD_EDIT_CAR_STATUS'
const CAR_VALIDATE = 'CAR_VALIDATE'

// STATE
const state = {
    authUser: '',
    loading: false,
    error: null,
    cars: '',
}
// GETTERS
const getters = {
    Getloading: state => state.loading,
    GetError: state => state.error,
    GetUser: state => {
        return state.authUser
    },
    IsAdmin: state => {
        return !HasEmptyJson(state.authUser) && state.authUser.isAdminRole;
    },




}


// MUTATIONS
const mutations = {
    [LOGIN_REGISTER_UPDATE_USER_STATUS](state, obj) {
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
    [UPDATE_CARS_STATUS](state, obj) {
        state.cars = obj;
    },
    [ADD_EDIT_CAR_STATUS](state, obj) {
        isFind = false;
        for (var i = 0; i < state.cars.data.length; i++) {
            if (state.cars.data[i].id == obj.data.id) {
                state.cars.data[i] = obj.data;
                isFind = true;
                break;
            }
        }
        if (isFind) {
            state.cars.data.push(obj.data);
        }

    }

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

    async loginAuth({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);

        try {
            console.log(obj.data);
            const authUser = await axios.post('/api/auth', {
                email: obj.data.email,
                password: obj.data.password,
            });

            commit(SET_LOADING, false);
            commit(LOGIN_REGISTER_UPDATE_USER_STATUS, authUser);
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
            commit(LOGIN_REGISTER_UPDATE_USER_STATUS, authUser);
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
    async UpdateUser({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
            const authUser = await axios.put('/api/user', {
                id: obj.data.id,
                avatarUrl: obj.data.avatarUrl,
                firstName: obj.data.firstName,
                lastName: obj.data.lastName,
                imgType: obj.data.imgType
            });
            commit(SET_LOADING, false);
            commit(LOGIN_REGISTER_UPDATE_USER_STATUS, authUser);

        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.message);
        }
    },
    async UpdateAuthUser({ commit }) {
        try {
            const authUser = await axios.get('/api/user');
            commit(LOGIN_REGISTER_UPDATE_USER_STATUS, authUser);
        }
        catch (error) {

        }
    },
    async UpateCarList({ commit }) {
        try {
            const cars = await axios.get('/api/car');
            commit(UPDATE_CARS_STATUS, cars);
        }
        catch (error) {
            commit(SET_ERROR, 'не загружается список машин');
        }
    },

    async AddOrEditCar({ commit }, obj) {
        commit(CLEAR_ERROR);
        commit(SET_LOADING, true);
        try {
          
            const car = await axios.put('/api/car', obj.data);
            commit(SET_LOADING, false);
            commit(ADD_EDIT_CAR_STATUS, car);
        }
        catch (error) {
            commit(SET_LOADING, false);
            commit(SET_ERROR, error.response.data);
        }
    },
   

});


export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters
});
