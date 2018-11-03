<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-start justify-center wrap fill-height>
                <h1> {{CreateOrEdit}} модели  </h1>
            </v-layout>
        </v-container>

        
        <v-container fluid grid-list-md>
            <v-layout row justify-center wrap>

                <v-flex sm5 md4 lg3>
                    <v-layout column row>
                        <v-flex sm9 md6 lg8  >
                            <v-card elevation-5 >
                                <div style="padding:5px 15px;">
                                    <v-img :src="car.getImg" alt="аватар" 
                                           aspect-ratio="1.69" class="grey lighten-2"></v-img>
                                </div>
                                <v-card-actions>
                                    <v-layout align-start justify-space-around>
                                        <v-btn v-if="imgIsChanged" v-on:click="imgReset">отмена</v-btn>
                                        <upload-btn title="загрузить" v-bind:fileChangedCallback="uploadFileFunction"></upload-btn>
                                    </v-layout>
                                 
                                </v-card-actions>
                            </v-card>
                        </v-flex>
                        <v-flex xs12 sm9 md9 lg1  style="margin:15px 0;">
                            <v-layout row>
                                <v-flex d-flex >
                                    <v-card elevation-5>
                                        <form id="updateCarForm2" @submit.prevent="onSubmit">
                                            <v-card-text>
                                                <v-text-field v-model="car.title"
                                                              v-validate="'required|min:1|max:60'"
                                                              :error-messages="errors.collect('car_title')"
                                                              autocomplete="off"
                                                              data-vv-as="имя"
                                                              v-on:change="changeText()"
                                                              required prepend-icon="email" name="car_title" label="имя"></v-text-field>

                                                <v-textarea v-model="car.description"
                                                            v-validate="'required|min:1|max:600'"
                                                            :error-messages="errors.collect('car_description')"
                                                            autocomplete="off"
                                                            data-vv-as="описание"
                                                            v-on:change="changeText()"
                                                            required prepend-icon="email" name="car_description" label="описание"></v-textarea>

                                            </v-card-text>
                                        </form>
                                    </v-card>
                                </v-flex>
                            </v-layout>
                        </v-flex>
                    </v-layout>
                </v-flex>
                <v-flex sm6 md6 lg6>
                    <v-card elevation-5>
                        <form id="updateCarForm" @submit.prevent="onSubmit">
                            <v-card-text>
                                <v-text-field v-model="car.mileage"
                                              v-validate="'numeric|min_value:1|max_value:500000'"
                                              :error-messages="errors.collect('car_mileage')"
                                              autocomplete="off"
                                              data-vv-as="пробег"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_mileage" label="пробег(км)"></v-text-field>


                                <v-select v-model="car.carType"
                                          prepend-icon="email"
                                          :items="carClass"
                                          data-vv-as="клас авто"
                                          v-on:change="changeText()"
                                          label="клас авто"></v-select>



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
                    data-vv-as="кузов"
                    v-on:change="changeText()"
                    required prepend-icon="email" name="car_carCase" label="тип"></v-text-field>-->
                                <v-select v-model="car.carClass"
                                          prepend-icon="email"
                                          :items="carBodyType"
                                          data-vv-as="кузов"
                                          v-on:change="changeText()"
                                          label="кузов"></v-select>
                                <v-text-field v-model="car.status"
                                              v-validate="'required|min:1|max:60'"
                                              :error-messages="errors.collect('car_status')"
                                              autocomplete="off"
                                              data-vv-as="статус"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_status" label="статус"></v-text-field>

                                <v-select v-model="car.transmission"
                                          prepend-icon="email"
                                          v-validate="'required'"
                                          :error-messages="errors.collect('car_transmission')"
                                          :items="carTranmissionType"
                                          v-on:change="changeText()"
                                          data-vv-as="коробка"
                                          name="car_transmission"
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
                                              data-vv-as="двигатель"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="car_motor" label="двигатель"></v-text-field>
                                <v-checkbox v-model="car.visible"
                                            label="показывать на сайте"
                                            required></v-checkbox>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-spacer></v-spacer>
                                <router-link to="/admin/cars" tag="v-btn">назад</router-link>

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
    import axios from 'axios'
    import UploadButton from 'vuetify-upload-button';
    export default {
        $_veeValidate: {
            validator: 'new'
        },
        data() {
            return {
                defaultImg: '',
                uploadFileFunction: this.uploadFile,
                id: this.$route.params.id,

                IsModification: false,
                car: {},
                carImgType: '',
                carBodyType: ['Седан', 'Хэтчбек', 'Универсал', 'Лифтбэк', 'Купе', 'Кабриолет', 'Родстер', 'Тарга', 'Внедорожник'],
                carTranmissionType: ['механическая', 'робот', 'автомат', 'вариатор'],
                carClass: ['легковые', 'грузовые'],
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
                return this.id == '' || this.id == undefined ?false 
                    : this.car.getImg != this.defaultImg
            },
            CreateOrEdit() {
                return this.id == '' || this.id == undefined ? 'Создание' : 'Редактирование';
            }
        },
        beforeMount: function () {
            this.getCar();
        },
        methods: {
            changeText: () => {

            },
            imgReset() {
                this.car.getImg = this.defaultImg;
            },
            onSubmit() {

                this.$validator.validateAll().then((result) => {



                    if (result) {
                        var data = { title: this.car.title, id: this.car.id };
                        axios.post('/api/car/validate/title', data).then((result) => {
                           
                            if (result.data) {
                                //var dbcar = this.car;
                                //dbcar.imgType = this.carImgType
                                //this.$store.dispatch('AddOrEditCar', { data: dbcar })
                                //    .then(() => {
                                //        this.getCar();
                                //    });
                               
                            } else {
                                this.$store.dispatch('SET_ERROR', "такое имя уже используется");
                            }
                        });
                    }
                });
                return false;
            },
            uploadFile(e) {
                var test = /^image\//gm.test(e.type) && e.size < 1024 * 1024;
                if (test) {
                    this.imageName = e.name
                    if (this.imageName.lastIndexOf('.') <= 0) {
                        return
                    }
                    var fr = new FileReader()
                    fr.readAsDataURL(e);
                    fr.addEventListener('load', () => {
                        this.car.getImg = fr.result
                        this.carImgType = e.name.match(/.(jpg|png|gif)$/gm)[0]
                        document.getElementById("uploadFile").value = "";
                    });


                }
            },
            getCar() {
                var cars = this.$store.state.cars.data;
                for (var i = 0; i < cars.length; i++) {
                    if (cars[i].id === this.id) {
                        this.car = cars[i];
                        this.defaultImg = cars[i].getImg;
                        return cars[i];
                    }
                }
            },

        }
    }
</script>
<style>
</style>
