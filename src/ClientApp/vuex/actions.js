import axios from 'axios'

export const fetchInitialMessages = ({ commit }) => {
    return axios.get('/Home/InitialMessages').then(response => {
        commit("INITIAL_MESSAGES", response.data);
    }).catch(err => {
        console.log(err);
    });
}

export const GetMessages = ({ commit }, lastFetchedMessageDate) => {
    axios.get('/Home/FetchMessages?lastFetchedMessageDate=' + lastFetchedMessageDate).then(response => {
        commit("GET_MESSAGES", response.data);
    }).catch(err => {
        console.log(err);
    });
}