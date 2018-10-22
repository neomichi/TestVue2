<template>
    <div>
        <v-navigation-drawer fixed
                             v-model="drawer"
                             left
                             app temporary>
            <v-list dence>
                
                <v-list-tile avatar v-if="authUser">
                    <v-list-tile-avatar>
                        <img :src="authUser.avatarUrl" />
                    </v-list-tile-avatar>

                    <v-list-tile-content>
                        <v-list-tile-title>{{authUser.firstName}} {{authUser.lastName}} </v-list-tile-title>
                    </v-list-tile-content>
                    
                </v-list-tile>
             


              

                <v-list-tile v-for="route in routes"
                             :key="route.display"
                             :to="route.path">
                    <v-list-tile-action>
                        <v-icon></v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title v-text="route.display"> </v-list-tile-title>
                    </v-list-tile-content>


                </v-list-tile>
                <v-list-tile v-if="isAdmin"  to="/admin">
                      <v-list-tile-action  >
                      </v-list-tile-action>
                    <v-list-tile-content >
                        admin   
                    </v-list-tile-content>
                 </v-list-tile>
            </v-list>
        </v-navigation-drawer>
        <v-toolbar dark color="primary">
            <v-toolbar-side-icon v-on:click="drawer=!drawer"
                                 class="hidden-md-and-up">
            </v-toolbar-side-icon>
            <v-toolbar-title>
                <router-link to="/" tag="span" class="pointer">У нас хорошо {{user}}</router-link>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn v-for="route in routes" v-bind:key="route.title" v-bind:to="route.path" flat> {{route.display }}</v-btn>
            </v-toolbar-items>
            <v-spacer></v-spacer>
           
            <v-toolbar-items v-if="authUser" class="hidden-sm-and-down"> 

                <v-menu :nudge-width="100" :nudge-bottom="40" :open-on-hover="true">
                    <v-toolbar-title slot="activator">                      
                        <v-btn :to="{ name: 'user', params: { id: authUser.id }}" tag="span" class="pointer" flat>{{authUser.firstName}}  {{authUser.lastName}} </v-btn>                      
                    </v-toolbar-title>                    
                    <v-list light dense>
                        <v-list-tile style="" v-for="item in menuItems"
                                     :key="item.id"                                     
                                     @click="item.eventName({ name: 'user', params: { id: authUser.id }})">
                            <v-list-tile-title v-text="item.title"></v-list-tile-title>
                        </v-list-tile>
                    </v-list>
                </v-menu>
            </v-toolbar-items>


            <v-toolbar-items v-if="authUser" class="hidden-sm-and-down">
                <v-spacer></v-spacer>
                <v-btn icon>
                    <v-avatar>
                        <img :src="authUser.avatarUrl" />
                    </v-avatar>
                </v-btn>
            </v-toolbar-items>
        </v-toolbar>    
    </div>
</template>

<script>
    import { routes } from '../routes'
    import { carRoutes } from '../routes'
    import { userRoutes } from '../routes'
    import { authRoutes } from '../routes'
    import { HasEmptyJson } from "../app.js"
    import store from '../store'
    export default {       
        data() {
            return {
                carRoutes,
                drawer: false,
                user: '',
                menuItems: [
                    { title: 'Кабинет', id: 0, url: '', eventName: this.gotoLK },
                    { title: 'Выйти', id: 1, url: '', eventName: this.logout },
                    //{ title: '1', id: 1, url: 'info', eventName:''},
                    //{ title: '2', id: 2, url: 'info', eventName:''},
                    //{ title: '3', id: 3, url: 'info', eventName:''}
                ],
            }
        },      
        computed: {
            routes: function () {
                return (this.authUser) ? routes : routes.concat(authRoutes);
            },           
            authUser:function() {
                return store.state.authUser;
            },
            isAdmin() {
                cache: false;
                return this.$store.getters.IsAdmin;
            },
           
        },
        methods: {
            toggleCollapsed: function (event) {
                this.collapsed = !this.collapsed;
            },
            logout: function () {
                this.$store.dispatch('logOut');
            },
            gotoLK: function (obj) {
                this.$router.push(obj);                
            }


        },
        created: () => {            
                    
        },
    }
</script>

<style scoped>
    .pointer {
        cursor: pointer;
    }

    .btn--icon .avatar img {
        height: 36px;
        width: 36px;
    }

    .v-avatar .v-icon, .v-avatar .v-image, .v-avatar img {
        margin-bottom: 10px
    }
</style>
