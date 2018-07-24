import Vue from 'vue'
import Vuex from 'vuex'
import { fetchInitialMessages, GetMessages } from './actions'
import minBy from 'lodash/minBy';

Vue.use(Vuex)

const store = new Vuex.Store({
    state: { messages: [], lastFetchedMessageDate: -1 },

    mutations: {
        INITIAL_MESSAGES: (state, payload) => {
            if (state.messages.length==0) 
            state.messages = payload.messages;
            state.lastFetchedMessageDate = payload.lastFetchedMessageDate;
        },
        GET_MESSAGES: (state, payload) => {          
            state.messages = state.messages.concat(payload);
            state.lastFetchedMessageDate = minBy(state.messages, 'date').date;
        }
    },

    actions: {
        fetchInitialMessages,
        GetMessages
    },

    getters: {
        messages: state => state.messages,
        lastFetchedMessageDate: state => state.lastFetchedMessageDate
    }
});

export default store;