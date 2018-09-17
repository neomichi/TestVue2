import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import LoginPage from 'components/login'
import Car from 'components/car'
import AdminCarList from 'components/admin/admin-car-list'
import AdminHome from 'components/admin/admin-home'
import GridData from 'components/grid-data'
import User from 'components/user/user'
import { fail } from 'assert';





export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-th-list', icon: 'home' },
    { path: '/grid', component: GridData, display: 'таблица заказов' },
    { path: '/counter', component: CounterExample,   display: 'Counter', style: 'glyphicon glyphicon-th-list' },
    { path: '/fetch-data', component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' },
]

export const authRoutes = [
    { path: '/login', name:'login', component: LoginPage, display: 'войти', props: { loginPage: true }, style: 'glyphicon glyphicon-th-list' },
    { path: '/register', name: 'register',  component: LoginPage, display: 'регистрация', props: { loginPage: false }, style: 'glyphicon glyphicon-th-list' },

]


export const anotherRoutes = [
    { path: '/car/details/:id', name: 'car', component: Car, display: 'car' },

]

export const userRoutes = [    
    { path: '/user/:id', name: 'user', component: User, display: 'user' },
]


export const adminRoutes = [
    { path: '/admin/', name: 'adminHome', component: AdminHome, display: 'adminHome' },
    { path: '/admin/cars', name: 'adminCarList', component: AdminCarList, display: 'adminHome' },
]


