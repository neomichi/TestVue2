<template>
    <div>

            <div class="title align-center justify-start">
                <h4>админитратор</h4>
            </div>

            <v-layout align-center justify-center fill-height wrap>
                <v-btn v-for="route in routes" v-bind:key="route.title" v-bind:to="{name:route.name}" flat>
                    {{route.display}}
                </v-btn>
            </v-layout>
      
        <v-layout align-center justify-center row fill-height>
            <router-view></router-view>
        </v-layout>

    </div>
</template>
<script>
    import { adminRoutes } from '../../routes'
    export default {
        data() {
            return {

                routes: adminRoutes[0].children,

            }
        },


    }
</script>
<style>   
</style>
