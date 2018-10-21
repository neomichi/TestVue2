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
            <v-container fluid>
                <v-layout align-center justify-space-around row  wrap>
                    <v-flex v-for="car in getCar" v-bind:key="car.id" xs12 sm6 md3 style="padding:8px;">
                        <v-card style="align-items:stretch">
                            <v-img style="height:240px;" :src="car.getImg"
                                   aspect-ratio="2.75"></v-img>
                            <v-card-title primary-title>
                                <div style="height:8vw">
                                    <h3 class="headline mb-0">{{car.title}}</h3>
                                    <div>{{car.description}}</div>
                                </div>
                            </v-card-title>
                            <v-layout align-center justify-start row fill-height wrap>
                                <v-card-actions>
                                    <v-spacer></v-spacer>

                                    <v-btn v-on:click="viewCar(car.id)" flat color="orange">подробнее</v-btn>
                                    <v-btn raised color="primary">купить</v-btn>

                                    <v-spacer></v-spacer>
                                </v-card-actions>
                            </v-layout>
                        </v-card>

                    </v-flex>
                  
                </v-layout>
            </v-container>
        </div>
</template>
<script>

    import Vue from 'vue'
    import Car from './car'
    import metaInfo from 'vue-meta'

    Vue.component('car', Car, metaInfo);
    
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

        beforeMount() {
            this.$store.dispatch('UpateCarList');
        },
        computed: {
            getCar: function() {
                cache: false;
                return this.$store.state.cars.data
            }
        },
        methods: {
            viewCar: function (id) {
                this.$router.push({ name: 'car', params: { id: id } })
            }, 
        },    
    }
</script>
<style>
</style>
