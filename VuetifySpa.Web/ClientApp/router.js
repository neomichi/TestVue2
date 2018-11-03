import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'
import { carRoutes } from './routes'
import { userRoutes } from './routes'
import { authRoutes } from './routes'
import { adminRoutes } from './routes'


let router = new VueRouter({
    mode: 'history',
    routes: routes.concat(carRoutes, userRoutes, authRoutes,adminRoutes)
})



Vue.use(VueRouter);





export default router 
    

