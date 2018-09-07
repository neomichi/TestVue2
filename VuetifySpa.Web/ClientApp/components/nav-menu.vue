<template>
    <div>
        <v-navigation-drawer fixed
                             v-model="drawer"
                             left
                             app temporary>
            <v-list dence>
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
            <v-toolbar-side-icon
                v-on:click="drawer=!drawer" 
                class="hidden-md-and-up" >
            </v-toolbar-side-icon>
            <v-toolbar-title >
                <router-link to="/" tag="span" class="pointer" >У нас хорошо</router-link>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn v-for="route in routes" v-bind:key="route.title" v-bind:to="route.path"  flat> {{route.display }}</v-btn>
            </v-toolbar-items>
        </v-toolbar>
    </div>

</template>

<script>
    import { routes } from '../routes'
    import { anotherRoutes } from '../routes'


    export default {
        data() {
            return {
                routes,
                anotherRoutes,
                drawer: false,
            }
        },
        computed: {
            showForm: function () {
                cache: false;
                var user = this.$store.getters.GetUser;
                return user;
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
        cursor:pointer;
    }
</style>
