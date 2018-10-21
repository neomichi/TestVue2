<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12 sm8 md5>
                    <h1 style="overflow:hidden">Курс популярных валют к usd</h1>
                    <h4>парсим с coinmarketcap.com чистым js</h4>
                </v-flex>
            </v-layout>
        </v-container>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>           
                <v-flex xs12 sm12 md8 lg6>
                    <v-data-table :headers="headers"
                                  :items="tableData"
                                  :loading="true"
                                  class="elevation-1">                        
                        <template slot="items" slot-scope="props">
                            <td>{{ props.item.name }}</td>
                            <td class="">{{ props.item.symbol }}</td>
                            <td class="">{{ props.item.rank }}</td>
                            <td class="">{{ props.item.quotes.USD.price }}</td>
                            <td class="">{{ props.item.quotes.USD.percent_change_24h }}</td>
                            
                        </template>
                    </v-data-table>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        data() {
            return {
                headers: [
                    { text: 'имя ', value: 'name'},
                    { text: 'символ', value: 'symbol' },
                    { text: 'ранк', value: 'rank' },
                    { text: 'текущая цена($)', value: 'quotes.USD.price' },
                    { text: 'изменился за 24часа(%)', value: 'quotes.USD.percent_change_24h' },

                ],
                tableData: []
            }
        },
        beforeMount: async function () {
            var url = "https://api.coinmarketcap.com/v2/ticker/?limit=10";
            const tableData = await axios.get(url);
            var table = tableData.data.data;       
            for (var row in table) {               
                this.tableData.push(table[row]);
            }

            //var aa = array.map(x => { return  [ x.name, x.symbol, x.rank, x.quotes.USD.price, x.quotes.USD.percent_change_24h ] });
            //console.log(aa);

            // this.headers.push({ text: 'Iron1 (%)', value: 'iron' })
        },
    }
</script>

<style>
</style>
