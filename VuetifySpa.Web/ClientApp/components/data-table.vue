<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12 sm8 md5>
                    <h1 style="overflow:hidden">DataTable и 5к данных </h1>
                    <h4>server paging</h4>
                </v-flex>
            </v-layout>
        </v-container>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12 sm12 md11 lg10>
                    <v-data-table v-model="selected"
                                  :headers="headers"
                                  :items="transports"
                                  :pagination.sync="pagination"
                                  :total-items="totalTransports"
                                  :loading="loading"
                                  select-all
                                  class="elevation-1">
                        <template slot="items" slot-scope="props">
                            <tr :active="props.selected" @click="props.selected = !props.selected">
                                <td>
                                    <v-checkbox :input-value="props.selected"
                                                primary
                                                hide-details>

                                    </v-checkbox>
                                </td>
                                <td class="">{{ props.item.brand }}</td>
                                <td class="">{{ props.item.cityMpg }}</td>
                                <td class="">{{ props.item.classification }}</td>
                                <td class="">{{ props.item.driveline }}</td>
                                <td class="">{{ props.item.engineType }}</td>
                                <td class="">{{ props.item.fuelType }}</td>
                            </tr>
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
                selected: [],
                totalTransports: 0,
                transports: [],
                loading: true,
                pagination: {},
                headers: [
                    { text: 'марка', value: 'brand' },
                    { text: 'литров на 100км', value: 'cityMpg' },
                    { text: 'трансмисия', value: 'classification' },
                    { text: 'привод', value: 'criveline' },
                    { text: 'тип двигателя', value: 'engineType' },
                    { text: 'тип топлива', value: 'fuelType' },

                ],

            }
        },
        watch: {
            pagination: {
                handler() {
                    this.getDataFromApi()
                        .then(data => {
                            this.transports = data.items
                            this.totalTransports = data.total
                        })
                },
                deep: true
            }
        },
        mounted() {
            this.getDataFromApi()
                .then(data => {
                    this.transports = data.items
                    this.totalTransports = data.total
                })
        },
        methods: {
            toggleAll() {
                console.log(response.data);
            },
            getDataFromApi() {
                this.loading = true;
                return new Promise((resolve, reject) => {
                    const { sortBy, descending, page, rowsPerPage } = this.pagination

                    const tableData = axios({
                        url: '/api/transport',
                        method: 'post',
                        data: {
                            sortBy: sortBy,
                            descending: descending,
                            page: page,
                            rowsPerPage: rowsPerPage,
                        }
                    }).then(response => {
                        var items = response.data.items;
                        var total = response.data.total;
                        resolve({
                            items,
                            total
                        });

                    });
                });
            }
        }
    }
</script>

<style>
</style>
