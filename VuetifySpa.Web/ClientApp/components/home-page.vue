    <template>
        <div>
            <v-container fluid>
                <v-layout row>
                    <v-flex xs12>                       
                        <v-carousel>
                            <v-carousel-item v-for="car in getCar"
                                             :key="car.id"
                                             :src="car.getImg"></v-carousel-item>
                        </v-carousel>
                    </v-flex>
                </v-layout>
            </v-container>           
            <v-container fluid wrap>
                <div class="cars">
                    <v-flex v-for="car in getCar" v-bind:key="car.id" xs12 sm6 md4 lg3>
                        <v-card style="flex-basis:auto;margin:10px;">
                            <v-img style="height:250px;" :src="car.getImg"
                                   aspect-ratio="2.75"></v-img>
                            <v-card-title primary-title style="min-height:20vh">
                                <div>
                                    <h3 class="headline mb-0">{{car.title}}</h3>
                                    <div>{{car.description}}</div>
                                </div>
                            </v-card-title>
                            <v-layout align-center justify-content-around row>
                                <v-card-actions>

                                    <v-btn v-on:click="viewCar(car.id)" flat color="orange">подробнее</v-btn>
                                    <v-btn raised color="primary">купить</v-btn>

                                    <v-spacer></v-spacer>
                                </v-card-actions>
                            </v-layout>
                        </v-card>
                    </v-flex>
                </div>

                 
               
            </v-container>
        </div>
</template>
<script>

    import Vue from 'vue'   
    import metaInfo from 'vue-meta'
    Vue.component(metaInfo);
    
    export default {
        data() {
            return {
                metaInfo: {
                    title: '!работает',
                    titleTemplate: '%s - Bay!',
                    htmlAttrs: {
                        lang: 'ru',
                    }
                },
                items: [],
                
            }
        },

        //beforeMount() {
        //    this.$store.dispatch('UpateCarList');
        //},
        computed: {
            getCar: function () { 
                cache: false;
                var data = this.$store.getters.GetCarOnMain;                
                return data;
            }
        },
        methods: {
            viewCar: function (id) {
            
                var cars = this.$store.state.cars.data;
                var car = '';
                for (var i = 0; i < cars.length; i++) {
                    if (cars[i].id === id) {
                        car = cars[i];
                    }
                }
                if (car != undefined && car != '') {    
                    console.log(car.title)
                    this.$router.push({ name: 'car', params: { title: car.title.trim(), id: car.id }})
                }
            }, 
        },    
    }
</script>
<style scoped>
    .cars {
        display: -webkit-box;
        display: -moz-box;
        display: -webkit-flex;
        display: -ms-flexbox;
        display: flex;
        -webkit-flex-wrap: wrap;
        -ms-flex-wrap: wrap;
        flex-wrap: wrap;
        flex-direction: row;
        flex-direction: row;
        flex-direction: row;
        align-items: stretch;
        justify-content: space-around
    }
</style>
