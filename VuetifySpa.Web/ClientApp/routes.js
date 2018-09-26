import HomePage from 'components/home-page'
import LoginPage from 'components/login'
import Car from 'components/car'
import AdminCarList from 'components/admin/admin-car-list'
import AdminHome from 'components/admin/admin-home'
import GridData from 'components/grid-data'
import User from 'components/user/user'
import cryptaData from 'components/crypta'
import { fail } from 'assert';
import store from './store'




export const routes = [
    { path: '/', name: 'home', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-th-list', icon: 'home' },
    { path: '/grid', name: 'grid', component: GridData, display: 'таблица заказов' },
    { path: '/crypta', name: 'crypta', component: cryptaData, display: 'курс крипты', style: 'glyphicon glyphicon-th-list' },
    { path: '/admin', name: 'adminHome', component: AdminHome, display: 'admin', style: 'glyphicon glyphicon-th-list' }
]

export const authRoutes = [
    { path: '/login', name: 'login', component: LoginPage, display: 'войти', props: { loginPage: true }, style: 'glyphicon glyphicon-th-list' },
    { path: '/register', name: 'register', component: LoginPage, display: 'регистрация', props: { loginPage: false }, style: 'glyphicon glyphicon-th-list' },  
]


export const anotherRoutes = [
    { path: '/car/details/:id', name: 'car', component: Car, display: 'car' },

]

export const userRoutes = [    
    {
        path: '/user/:id', name: 'user', component: User, display: 'user', beforeEnter: (to, from, next) =>
        {
            
            if (store.getters.IsAuth) {

                next()
                return
            }
            next('/login?authError=true');
        },


    },    
    
]


export const adminRoutes = [    
    
    { path: '/admin/cars', name: 'adminCarList', component: AdminCarList, display: 'adminHome' },
]


