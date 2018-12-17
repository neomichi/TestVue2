<template>
    <div>

        <v-layout align-center justify-center>
            <v-flex xs12 sm8 md5>
                <h1 style="overflow:hidden">DataTable и 5к данных </h1>
            </v-flex>
        </v-layout>

        <v-container fluid fill-height>
            <v-layout align-center justify-end>

                <div style="margin:0 1vw">
                    <v-text-field v-model="search"
                                  append-icon="search"
                                  label="поиск"
                                  single-line
                                  v-validate="'required|min:3'"
                                  :error-messages="errors.collect('filter_search')"
                                  name="filter_search"
                                  id="filter_search"
                                  data-vv-as="поиск"
                                  title="укажите больше 2 символов"
                                  hide-details v-on:change="validSearch()"></v-text-field>
                </div>
                <div>
                    <v-btn v-on:click="getDataFromApi(pdfExport=true)" class="export" fab small color="white">
                        <img src="/img/icon/pdf.svg"
                             alt="скачать в pdf" style="max-height:24px">
                    </v-btn>
                </div>
                <div>
                    <v-btn v-on:click="getDataFromApi(excellExport=true)" class="export" fab small color="white">
                        <img src="/img/icon/xls.svg"
                             alt="скачать в excell" style="max-height:24px;">
                    </v-btn>
                </div>

            </v-layout>
        </v-container>




        <v-container fluid fill-height>
            <v-layout align-center justify-center>

                <v-flex xs12 sm12 md11 lg12>
                    <v-data-table v-model="selected"
                                  :headers="headers"
                                  :items="transports"
                                  :pagination.sync="pagination"
                                  :total-items="totalTransports"
                                  :loading="loading"
                                  select-all
                                  class="elevation-1">
                        <template slot="items" slot-scope="props">
                            <tr v-bind:active="props.selected" v-on:click="props.selected = !props.selected">
                                <td>
                                    <v-checkbox v-bind:input-value="props.id"
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
                                <td class="">{{ props.item.year }}</td>
                            </tr>
                        </template>
                    </v-data-table>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script>
    import saveAs from 'file-saver';
    import Vue from 'vue'
    import axios from 'axios'
    import { valid } from 'semver';
    export default {
        $_veeValidate: {
            validator: 'new'
        },
        data() {
            return {
                search: '',
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
                    { text: 'год выпуска', value: 'year' },
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
            validSearch() {
                return this.getDataFromApi();
            },
            toggleAll() {
                console.log(response.data);
            },
            getDataFromApi(excellExport = false, pdfExport = false) {
                this.loading = true;
                return new Promise((resolve, reject) => {
                    var exportList = this.selected.map(item => item.id);
                    let search = this.search.length > 2 ? this.search : '';
                    const { sortBy, descending, page, rowsPerPage } = this.pagination

                    var postData = {
                        sortBy: sortBy,
                        descending: descending,
                        page: page,
                        rowsPerPage: rowsPerPage,
                        search: search
                    };

                    if (excellExport) {
                        postData.excelData = exportList;  
                    }
                    if (pdfExport) {
                        postData.pdfData = exportList;
                    }

                    const tableData = axios({
                        url: '/api/transport',
                        method: 'post',
                        data: postData
                    }).then(response => {
                        if (excellExport) {
                            saveAs(response.data, 'Export.xlsx');
                        }
                        if (pdfExport) {
                            saveAs(response.data, 'Export.pdf');
                        }

                        var items = response.data.items;
                        var total = response.data.total;
                        resolve({
                            items,
                            total
                        });
                    });

                })
            }
        }
    }



</script>

<style scoped>
    .export:focus {
        outline: none;
    }
</style>
