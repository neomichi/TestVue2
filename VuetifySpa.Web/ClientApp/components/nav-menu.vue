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
                        админка   
                    </v-list-tile-content>
                 </v-list-tile>
            </v-list>
        </v-navigation-drawer>
        <v-toolbar dark color="white" elevation-0>
            <v-toolbar-side-icon v-on:click="drawer=!drawer"
                                 class="hidden-md-and-up">
            </v-toolbar-side-icon>
            <v-toolbar-title>
                <router-link to="/" tag="span" class="pointer ">У нас хорошо {{user}}</router-link>
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
                        <v-list-tile style="" v-for="item in userMenuRoutes"
                                     :key="item.id"                                     
                                     @click=gotoLK(item.urlparam);>
                            <v-list-tile-title v-text="item.display"></v-list-tile-title>
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
            }
        },      
        computed: {
            userMenuRoutes() {             
                var usermenuRoutes = userRoutes.map((item, i) =>
                    ({
                        display: item.display,
                        id: i,
                        name: name,
                        urlparam: { name: item.name, params: { id: this.authUser.id }},                      
                    }));
                var logoutLk = { display: 'выйти', name: 'logout', urlparam: '', id: -1 };
                usermenuRoutes.push(logoutLk)

                return usermenuRoutes;
            },
            routes() {
                return (this.authUser) ? routes : routes.concat(authRoutes);
            },           
            authUser() {
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
            gotoLK: function (obj) {     
               return obj == ''? this.$store.dispatch('logOut'):this.$router.push(obj);
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
    .v-toolbar .router-link-active {
        color: #808080
    }

    .theme--dark.v-btn {
        color: #808080;
        text-decoration: none;
    }
    .v-btn--active.v-btn{
        color: #ff6a00;
    }
    
</style>
