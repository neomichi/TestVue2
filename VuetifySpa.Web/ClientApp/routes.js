import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import LoginPage from 'components/login'


export const routes = [
    { path: '/', component: HomePage, display: 'Home',   style: 'glyphicon glyphicon-th-list' },
    { path: '/counter', component: CounterExample,   display: 'Counter', style: 'glyphicon glyphicon-th-list' },
    { path: '/fetch-data', component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' },
    { path: '/login', component: LoginPage, display: 'login', style: 'glyphicon glyphicon-th-list' },
]

