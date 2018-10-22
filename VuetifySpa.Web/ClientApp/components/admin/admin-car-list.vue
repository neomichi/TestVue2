<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12>
                    <h1>Список техники </h1>
                </v-flex>
            </v-layout>
        </v-container>

        <v-container fluid>
            <v-layout align-center justify-center>
                <v-flex xs12>
                    <v-data-table :headers="headers"
                                  :items="cars"
                                  hide-actions
                                  class="elevation-1">
                        <template slot="items" slot-scope="props">
                            <td>{{ props.item.title }}</td>
                            <td class="text-xs-center">{{ props.item.carType }}</td>
                            <td class="text-xs-center">{{ props.item.quantity }}</td>
                            <td class="text-xs-center">{{ props.item.birthYear }}</td>
                            <td class="text-xs-center">{{ props.item.motor }}</td>

                            <td class="text-xs-center">

                                <div class="checkbox-left">
                                    <v-spacer></v-spacer>
                                    <v-checkbox :readonly="true"
                                                v-model="props.item.visible">
                                    </v-checkbox>
                                </div>

                            </td>
                            <td class="justify-center align-center layout px-0">
                                <v-btn flat icon color="indigo" class="mr-2"
                                       @click="createEditCar(props.item.id,false)">
                                    <v-icon>edit</v-icon>
                                </v-btn>
                                <v-btn flat icon class="mr-2" color="red"
                                       @click="deleteItem(props.item.id)">
                                    <v-icon>delete</v-icon>
                                </v-btn>
                            </td>
                        </template>
                    </v-data-table>
                </v-flex>
            </v-layout>
        </v-container>
        <dialog v-bind:dialog="dialogState"></dialog>
    </div>
</template>
<script>
    import dialog from '../dialog'
    export default {
        data() {
            return {
                cars: [],
                dialogState: true,
                headers: [
                    {
                        text: 'название',
                        align: 'center',
                        sortable: true,
                        value: 'title'
                    },
                    { align: 'center', text: 'тип авто', value: 'carType' },
                    { align: 'center', text: 'кол-во', value: 'quantity' },
                    { align: 'center', text: 'дата создания', value: 'birthYear' },
                    { align: 'center', text: 'тип двигателя', value: 'motor' },
                    { align: 'center', text: 'видимось', value: 'visible' },
                    { text: '', value: 'name', sortable: false }
                ],

            }
        },
        computed: {
        },
        beforeMount: function () {
            this.$store.dispatch('UpateCarList').then(() => {
                this.cars = this.$store.state.cars.data
            });
            
        },
        methods: {
            createEditCar(id, createOrEdit) {
                this.$router.push({ name: 'adminEditCar', params: { id: id, createOrEdit: createOrEdit } })
            },      
            deleteItem(id) {
                console.log(id);
            }


        }
    }
</script>
<style>
    @media (min-width: 400px) {
        .checkbox-left {
            padding-left: 4vw;
        }
    }

    @media (min-width: 700px) {
        .checkbox-left {
            padding-left: 3vw;
        }
    }

    @media (min-width: 1000px) {
        .checkbox-left {
            padding-left: 2vw;
        }
    }
</style>
