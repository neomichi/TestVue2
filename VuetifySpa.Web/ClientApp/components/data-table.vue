<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12 sm8 md5>
                    <h1 style="overflow:hidden">DataTable и 5к данных </h1>
                    <h4> server paging </h4>
                </v-flex>
            </v-layout>
        </v-container>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12 sm12 md10 lg8>
                    <v-data-table :headers="headers"
                                  :items="transports"
                                  :pagination.sync="pagination"
                                  :total-items="totalTransports"
                                  :loading="loading"
                                  class="elevation-1">
                        <template slot="items" slot-scope="props">
                            <th>
                                <v-checkbox :input-value="props.all"
                                            :indeterminate="props.indeterminate"
                                            primary
                                            hide-details
                                            @click="toggleAll"></v-checkbox>
                            </th>
                            <td class="">{{ props.item.brand }}</td>
                            <td class="">{{ props.item.cityMpg }}</td>
                            <td class="">{{ props.item.classification }}</td>
                            <td class="">{{ props.item.driveline }}</td>
                            <td class="">{{ props.item.engineType }}</td>
                            <td class="">{{ props.item.fuelType }}</td>

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
                totalTransports: 0,
                transports: [],
                loading: true,
                pagination: {},
                headers: [
                    { text: '#', value: 'Id' },
                    { text: 'марка', value: 'brand' },
                    { text: 'Миль на галлон', value: 'cityMpg' },
                    { text: 'классификация', value: 'classification' },
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
                        console.log(response.data);
                    });
                });
            }
        }
    }
</script>

<style>
</style>
