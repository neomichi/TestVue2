<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-start justify-center wrap fill-height>
                <h1> {{CreateOrEdit}} модели  </h1>
            </v-layout>
        </v-container>
        <v-container fluid grid-list-sm>
            <v-layout row wrap align-start justify-space-around >
            <v-flex d-flex xs12 sm4 md4>
                    <v-layout row wrap justify-center>
                        <v-flex d-flex style="height:240px;">
                            <v-card elevation-5>
                                <v-img :src="car.getImg" max-height="180" alt="аватар"
                                       aspect-ratio="1" class="grey lighten-2"></v-img>
                                <v-card-actions>
                                    <v-layout align-end justify-space-around style="margin-top:5px;">
                                        <v-btn v-if="imgIsChanged" v-on:click="imgReset">отмена</v-btn>
                                        <upload-btn title="загрузить" v-bind:fileChangedCallback="uploadFileFunction"></upload-btn>
                                    </v-layout>
                                </v-card-actions>
                            </v-card>
                        </v-flex>
                        <v-flex d-flex style="margin-top:10px;">
                            <v-layout row>
                                <v-flex d-flex>
                                    <v-card elevation-5>
                                        <form id="updateCarForm2" @submit.prevent="onSubmit">
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


                                            </v-card-text>
                                        </form>
                                    </v-card>
                                </v-flex>
                            </v-layout>
                        </v-flex>
                    </v-layout>
                </v-flex>
            <v-flex  xs12 sm8 md6 lg5>
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

                                    
                                    <v-select v-model="car.carClass"
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
                                    <v-select v-model="car.carCase"
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
                carClass:['легковые','грузовые'],
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
            CreateOrEdit() {
                cache: false;
                return this.id == '' ? 'Создание' : 'Редактирование';
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
                        var dbcar = this.car;
                        dbcar.imgType = this.carImgType
                        this.$store.dispatch('AddOrEditCar', { data: dbcar })
                            .then(() => {
                                this.getCar();
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
