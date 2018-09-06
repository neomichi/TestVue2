    <template>
        <div>
            <v-container fluid>
                <v-layout row>
                    <v-flex xs12>                       
                        <v-carousel>
                            <v-carousel-item v-for="item in items"
                                             :key="item.id"
                                             :src="item.img"></v-carousel-item>
                        </v-carousel>
                    </v-flex>
                </v-layout>
            </v-container>
            <v-container grid-list-lg>
                <v-layout row wrap>
                    <v-flex  v-for="item in items" v-bind:key="item.id" xs12 sm6 md3>
                        <v-card >
                            <v-card-media style="height:240px;" :src="item.img"
                                   aspect-ratio="2.75"></v-card-media>
                            <v-card-title primary-title>
                                <div>
                                    <h3 class="headline mb-0">{{item.title}}</h3>
                                    <div>{{item.description}}</div>
                                </div>
                            </v-card-title>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn flat color="orange">посмотреть</v-btn>
                                <v-btn raised color="primary">купить</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-flex>
                </v-layout>
            </v-container>
        </div>
</template>
<script>
    export default {
        data() {
            return {
                items: [
                    {
                        id: 1,
                        title: 'красота номер 1',
                        description: 'красота красиво супер гут 1',
                        promo:false,
                        img: '/img/ferrari.jpg'
                    },
                    {
                        id: 2,
                        title: 'красота номер 2',
                        description: 'красота красиво супер гут 2',
                        promo: true,
                        img: '/img/bentley.jpg'
                    },             
                    {
                        id: 3,
                        title: 'красота номер 3',
                        description: 'красота красиво супер гут 3',
                        promo: true,
                        img: '/img/shevrole.jpg'
                    },
                    {
                        id: 4,
                        title: 'красота номер 4',
                        description: 'красота красиво супер гут 4',
                        promo: true,
                        img: '/img/maserati.jpg'
                    },

                ]
            }
        },
    }
</script>
<style>
</style>
