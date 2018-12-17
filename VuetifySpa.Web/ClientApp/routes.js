import HomePage from 'components/home-page'
import IndexPage from 'components/index'
import LoginPage from 'components/login'
import Car from 'components/car'
import AdminOrderList from 'components/admin/admin-order-list'
import AdminUserList from 'components/admin/admin-user-list'
import AdminCarList from 'components/admin/admin-car-list'
import AdminCarEditCreate from 'components/admin/admin-car-create-or-edit'
import AdminHome from 'components/admin/admin-home'
import About from 'components/about'
import DataTable from 'components/data-table'
import User from 'components/user/user'
import UserMessages from 'components/user/messages'
import cryptaData from 'components/crypta'
import { AdminRules, UserRules, AuthRules } from './route-rules'
    




export const routes = [
    { path: '/', name: 'index', component: IndexPage, display: 'главная', style: 'glyphicon glyphicon-th-list', icon: 'home' },
    { path: '/home', name: 'home', component: HomePage, display: 'машинки', style: 'glyphicon glyphicon-th-list', icon: 'home' },
    { path: '/about', name: 'about', component: About, display: 'обомне' },
    { path: '/crypta', name: 'crypta', component: cryptaData, display: 'курс крипты', style: 'glyphicon glyphicon-th-list' },
    { path: '/data-table', name: 'dataTable', component: DataTable, display: 'тест DataTable', style: 'glyphicon glyphicon-th-list' }

]

export const authRoutes = [
    { path: '/login', name: 'login', component: LoginPage, display: 'войти', props: { loginPage: true }, style: 'glyphicon glyphicon-th-list', beforeEnter: AuthRules },
    { path: '/register', name: 'register', component: LoginPage, display: 'регистрация', props: { loginPage: false }, style: 'glyphicon glyphicon-th-list', beforeEnter: AuthRules },
]


export const carRoutes = [
    { path: '/car/:title', name: 'car', component: Car, display: 'car' },

]

export const userRoutes = [
    {
        path: '/user/:id', name: 'user', component: User, display: 'кабинет', beforeEnter: UserRules
    }, {
        path: '/user/message/:id', name: 'userMessages', component: UserMessages, display: 'мои сообщения', beforeEnter: UserRules
    }
  
]

export const adminRoutes = [
    {
        path: '/admin', name: 'adminHome', component: AdminHome, display: 'админка',
        beforeEnter: AdminRules,
        children: [
            { path: 'cars', name: 'adminCarlist', component: AdminCarList, display: 'список машин' },
            { path: 'users', name: 'adminUserlist', component: AdminUserList, display: 'список пользователей' },
            { path: 'orders', name: 'adminOrderlist', component: AdminOrderList, display: 'список заказов' }
        ],
    },
    { path: '/admin/create-car', name: 'adminCreateCar', component: AdminCarEditCreate, display: 'создать машинку', beforeEnter: AdminRules },
    { path: '/admin/:id/edit-car', name: 'adminEditCar', component: AdminCarEditCreate, display: 'редактировать машинку', beforeEnter: AdminRules },
    


]



