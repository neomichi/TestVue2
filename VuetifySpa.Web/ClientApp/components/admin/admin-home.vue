    <template>     
        <div>
            <h1>админитратор</h1> 
          

            <v-btn v-for="route in routes" v-bind:key="route.title" v-bind:to="{name:route.name}" flat>
                {{route.display}}
            </v-btn>

            <router-view></router-view>
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
