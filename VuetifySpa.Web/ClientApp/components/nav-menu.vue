<template>
    <div>
        <v-navigation-drawer fixed
                             v-model="drawer"
                             left
                             app temporary>
            <v-list dence>
                <v-list-tile avatar>
                    <v-list-tile-avatar>
                        <img src="https://randomuser.me/api/portraits/men/85.jpg">
                    </v-list-tile-avatar>

                    <v-list-tile-content>
                        <v-list-tile-title>John Leider</v-list-tile-title>
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

            </v-list>
        </v-navigation-drawer>
        <v-toolbar dark color="primary">
            <v-toolbar-side-icon v-on:click="drawer=!drawer"
                                 class="hidden-md-and-up">
            </v-toolbar-side-icon>
            <v-toolbar-title>
                <router-link to="/" tag="span" class="pointer">У нас хорошо</router-link>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn v-for="route in routes" v-bind:key="route.title" v-bind:to="route.path" flat> {{route.display }}</v-btn>
            </v-toolbar-items>
            <v-spacer></v-spacer>
            
            <v-toolbar-items v-if="authUser"  class="hidden-sm-and-down">
                <v-btn tag="span" flat>
                    Noname {{authUser}}
                </v-btn>             
            </v-toolbar-items>
            <v-toolbar-items  v-if="authUser"  class="hidden-sm-and-down">
                <v-spacer></v-spacer>
                <v-btn icon>
                    <v-avatar>
                        <img src="https://randomuser.me/api/portraits/men/1.jpg">
                    </v-avatar>
                </v-btn>
            </v-toolbar-items>




        </v-toolbar>
</div>

</template>

<script>
    import { routes } from '../routes'
    import { anotherRoutes } from '../routes'
    import { userRoutes } from '../routes'
    import { HasEmptyJson } from "../app.js"

    export default {
        data() {
            return {               
                routes: routes.concat(userRoutes),
                anotherRoutes,
                drawer: false,
            }
        },
        computed: {
            authUser: function () {
                cache: false;
                var user = this.$store.getters.GetUser.then(x => {
                    console.log(x);
                })
            

                console.log(HasEmptyJson)
                return false;
            },
        },
        methods: {
            toggleCollapsed: function (event) {
                this.collapsed = !this.collapsed;
            },
        }
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
