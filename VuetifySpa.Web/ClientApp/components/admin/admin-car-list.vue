    <template>     
        <div>
            <h1>Список техники </h1>
            <v-data-table :headers="headers"
                          :items="desserts"
                          hide-actions
                          class="elevation-1">
                <template slot="items" slot-scope="props">
                    <td>{{ props.item.name }}</td>
                    <td class="text-xs-right">{{ props.item.calories }}</td>
                    <td class="text-xs-right">{{ props.item.fat }}</td>
                    <td class="text-xs-right">{{ props.item.carbs }}</td>
                    <td class="text-xs-right">{{ props.item.protein }}</td>
                    <td class="text-xs-right">{{ props.item.iron }}</td>
                </template>
            </v-data-table>
        </div>
</template>
<script>
    export default {
        data() {
            return {
                headers: [
                    {
                        text: 'название',
                        align: 'left',
                        sortable: true,
                        value: 'title'
                    },
                    { text: 'Calories', value: 'calories' },
                    { text: 'Fat (g)', value: 'fat' },
                    { text: 'Carbs (g)', value: 'carbs' },
                    { text: 'Protein (g)', value: 'protein' },
                    { text: 'Iron (%)', value: 'iron' }
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
    }
</script>
<style>
</style>
