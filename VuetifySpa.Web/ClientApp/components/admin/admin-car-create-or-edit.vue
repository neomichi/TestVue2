<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-start justify-center wrap fill-height>
                <h1> Редактирование модели </h1> {{defaultImg}}
            </v-layout>
        </v-container>
        <v-container fluid fill-height>
            <v-layout align-start justify-center wrap fill-height>
                <v-flex xs12 sm8 md4 lg3 style="margin:0 40px 40px 40px;">
                    <v-card elevation-5 height="240">
                        <v-img :src="car.getImg" max-height="180" alt="аватар"
                               aspect-ratio="1" class="grey lighten-2"></v-img>
                        <v-card-actions>
                            <v-layout align-end justify-center style="margin-top:5px;">
                                <v-btn v-if="imgIsChanged" v-on:click="imgReset">отмена</v-btn>
                                <upload-btn title="загрузить" v-bind:fileChangedCallback="uploadFileFunction"></upload-btn>
                            </v-layout>
                        </v-card-actions>
                    </v-card>
                </v-flex>
                <v-flex xs12 sm8 md6 lg5>
                    <v-card elevation-5>
                        <form id="updateForm" @submit.preven="onSubmit">
                            <v-card-text>
                                <v-text-field v-model="car.title"
                                              v-validate="'required|min:1|max:60'"
                                              :error-messages="errors.collect('car_title')"
                                              autocomplete="off"
                                              data-vv-as="название"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_title" label="название"></v-text-field>
                                <v-textarea v-model="car.description"
                                            v-validate="'required|min:1|max:600'"
                                            :error-messages="errors.collect('car_description')"
                                            autocomplete="off"
                                            data-vv-as="описание"
                                            v-on:change="changeText()"
                                            required prepend-icon="email" name="car_description" label="описание"></v-textarea>
                                <v-text-field v-model="car.birthYear"
                                              v-validate="'numeric|min_value:1990|max_value:2018'"
                                              :error-messages="errors.collect('car_birthYear')"
                                              autocomplete="off"
                                              data-vv-as="год выпуска"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_birthYear" label="год выпуска"></v-text-field>
                                <v-text-field v-model="car.quantity"
                                              v-validate="'numeric|min_value:1|max_value:100'"
                                              :error-messages="errors.collect('car_quantity')"
                                              autocomplete="off"
                                              data-vv-as="количество"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_quantity" label="количество"></v-text-field>
                                <!--<v-text-field v-model="car.carCase"
                            v-validate="'required|min:1|max:60'"
                            :error-messages="errors.collect('car_carCase')"
                            autocomplete="off"
                            data-vv-as="тип кузова"
                            v-on:change="changeText()"
                            required prepend-icon="email" name="car_carCase" label="тип"></v-text-field>-->
                                <v-select v-model="car.carCase"
                                          prepend-icon="email"
                                          :items="carBodyType"
                                          v-on:change="changeText()"
                                          label="тип кузова"></v-select>
                                <v-text-field v-model="car.status"
                                              v-validate="'required|min:1|max:60'"
                                              :error-messages="errors.collect('car_status')"
                                              autocomplete="off"
                                              data-vv-as="статус"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_status" label="статус"></v-text-field>
                                <!--<v-text-field v-model="car.transmission"
                                      v-validate="'required|min:1|max:60'"
                                      :error-messages="errors.collect('car_transmission')"
                                      autocomplete="off"
                                      data-vv-as="коробка"
                                      v-on:change="changeText()"
                                      required prepend-icon="email" name="car_transmission" label="коробка"></v-text-field>-->
                                <v-select v-model="car.transmission"
                                          prepend-icon="email"
                                          :items="carTranmissionType"
                                          v-on:change="changeText()"
                                          label="коробка"></v-select>
                                <v-text-field v-model="car.color"
                                              v-validate="'required|min:1|max:60'"
                                              :error-messages="errors.collect('car_color')"
                                              autocomplete="off"
                                              data-vv-as="цвет"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_color" label="цвет"></v-text-field>
                                <v-text-field v-model="car.motor"
                                              v-validate="'required|min:1|max:60'"
                                              :error-messages="errors.collect('car_motor')"
                                              autocomplete="off"
                                              data-vv-as="мотор"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_motor" label="мотор"></v-text-field>
                                <v-checkbox v-model="car.visible"
                                            label="показывать на сайте"
                                            required></v-checkbox>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-spacer></v-spacer>
                                <v-btn :disabled="IsModification" type="submit" color="primary" :loading="loading" :disable="loading">Сохранить</v-btn>
                                <!--<v-btn :disabled="IsModification" type="submit" color="primary" :loading="loading" :disable="loading">Сохранить</v-btn>-->
                            </v-card-actions>
                        </form>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>
<script>
    import Vue from 'vue'
    import UploadButton from 'vuetify-upload-button';
    export default {
        data() {
            return {
                defaultImg: '',
                uploadFileFunction: this.uploadFile,
                id: this.$route.params.id,
                createOrEdit: this.$route.params.createOrEdit,
                IsModification: false,
                car: {},
                carImgType: '',
                carBodyType: ['Седан', 'Хэтчбек', 'Универсал', 'Лифтбэк', 'Купе', 'Кабриолет', 'Родстер', 'Тарга'],
                carTranmissionType: ['механическая','робот','автомат','вариатор'],
            }
        },
        components: {
            'upload-btn': UploadButton
        },
        computed: {
            loading: function () {
                cache: false;
                return this.$store.getters.Getloading;
            },
            imgIsChanged: function () {
                cache: false;
                return this.car.getImg != this.defaultImg;
            },
        },
        beforeMount: function () {
            var cars = this.$store.state.cars.data;
            for (var i = 0; i < cars.length; i++) {
                if (cars[i].id === this.id) {
                    this.car = cars[i];
                    this.defaultImg = cars[i].getImg;
                    return cars[i];
                }
            }
        },
        methods: {
            getCar() {

            },
            changeText: () => {

            },
            imgReset() {
                this.car.getImg = this.defaultImg;
            },
            uploadFile(e) {             
                console.log(e);
                var test = /^image\//gm.test(e.type) && e.size < 512 * 1024;
                if (test) {
                    this.imageName = e.name
                    if (this.imageName.lastIndexOf('.') <= 0) {
                        return 
                    }
                    var fr = new FileReader()
                    fr.readAsDataURL(e)
                    fr.addEventListener('load', () => {
                        this.car.getImg = fr.result
                        this.carImgType = e.name.match(/.(jpg|png|gif)$/gm)[0]
                    })
                }
            },
        }
    }
</script>
<style>
</style>
