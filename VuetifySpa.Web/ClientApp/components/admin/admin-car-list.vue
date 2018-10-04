    <template>     
        <div>
            <v-container fluid fill-height>
                <v-layout align-center justify-center>
                    <v-flex xs12>
                        <h1>Список техники </h1>
                    </v-flex>
                </v-layout>
            </v-container>

            <v-container fluid fill-height>
                <v-layout align-center justify-center>


                    <v-flex xs12>
                        <v-data-table :headers="headers"
                                      :items="cars"
                                      hide-actions
                                      class="elevation-1">
                            <template slot="items" slot-scope="props">
                                <td>{{ props.item.title }}</td>
                                <td class="text-xs-right">{{ props.item.carType }}</td>
                                <td class="text-xs-right">{{ props.item.quantity }}</td>
                                <td class="text-xs-right">{{ props.item.birthYear }}</td>
                                <td class="text-xs-right">{{ props.item.motor }}</td>
                                <td class="text-xs-right">{{ props.item.visible }}</td>
                            </template>
                        </v-data-table>
                    </v-flex>
                </v-layout>
            </v-container>
        </div>
</template>
<script>
    export default {
        data() {
            return {
                cars:[],
                headers: [
                    {
                        text: 'название',
                        align: 'left',
                        sortable: true,
                        value: 'title'
                    },
                    { text: 'тип авто', value: 'carType' },
                    { text: 'кол-во', value: 'quantity' },
                    { text: 'дата создания', value: 'birthYear' },
                    { text: 'тип двигателя', value: 'motor' },
                    { text: 'видимось', value: 'visible' }
                ],
                desserts: [
                    {
                        id: 1,
                        title: 'красота номер 1',
                        name: 'name',
                        description: "description",                 
                        birthYear: 1990,
                        quantity: 20,
                        carcase: 'седан',
                        state: 'ремонт',
                        carBox: '1%'
                    },
                    {
                        value: false,
                        title: 'красота номер 1', 
                        name: 'name',
                        description: "description",              
                        fat: 9.0,
                        carbs: 37,
                        protein: 4.3,
                        iron: '1%'
                    },
                ]           
              
            }
        },
        computed: {            
        },
        beforeMount: function () {
            this.$store.getters.GetCars.then((result) => {
              
                this.cars= result.data;

            }) 
        },
        methods: {
           
        }
    }
</script>
<style>
</style>
