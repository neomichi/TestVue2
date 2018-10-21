<template>
    <div>
        <v-container fluid grid-list-lg>
            <v-layout row wrap justify-center>
                <v-flex xs10 sm4 md3 lg2>
                    <v-card elevation-5 height="240">

                        <v-img :src="user.avatarUrl" max-height="180"  alt="аватар" 
                               aspect-ratio="1" class="grey lighten-2"></v-img>


                        <v-card-actions>
                            <v-layout align-end justify-center style="margin-top:5px;">
                           
                                <upload-btn title="загрузить"  v-bind:fileChangedCallback="uploadFileFunction"  ></upload-btn>
                            </v-layout>

                        </v-card-actions>

                        
                    </v-card>
                </v-flex>
                <v-flex xs12 sm8 md6 lg4>
                    <v-card elevation-5 height="240">
                        <form id="updateForm" @submit.prevent="onSubmit">
                            <v-card-text>
                                <v-text-field v-model="user.firstName"
                                              v-validate="'required|min:3|max:60'"
                                              :error-messages="errors.collect('user_firstName')"
                                              autocomplete="off"
                                              data-vv-as="имя"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="user_firstName" label="Имя"></v-text-field>
                                <v-text-field v-model="user.lastName"
                                              v-validate="'required|min:3|max:60'"
                                              :error-messages="errors.collect('user_lastName')"
                                              autocomplete="off"
                                              data-vv-as="фамилия"
                                              v-on:change="changeText()"
                                              required prepend-icon="email" name="user_lastName" label="Фамилия"></v-text-field>
                            </v-card-text>

                            <v-card-actions>

                                <v-spacer></v-spacer>

                                <v-btn :disabled="IsModification" type="submit" color="primary" :loading="loading" :disable="loading">Сохранить</v-btn>
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
    import VeeValidate from 'vee-validate'
    import VeeValidateRu from 'vee-validate/dist/locale/ru'
    import axios from 'axios'
    import UploadButton from 'vuetify-upload-button';
    Vue.use(VeeValidate);
    export default {
        $_veeValidate: {
            validator: 'new'
        },
        components: {
            'upload-btn': UploadButton
        },
        data() {
            return {
                uploadFileFunction: this.uploadFile,
                imageFile:"", 
                def: {
                    avatarUrl: '',
                    firstName: '',
                    lastName: '',
                },
                user: {
                    avatarUrl: '',  
                    firstName: '',
                    lastName: '',
                    password: '',
                    avatarImgType:'',
                    id: this.$route.params.id
                },
            }
        },
        computed: {
            loading: function () {
                cache: false;
                return this.$store.getters.Getloading;
            },
            IsModification: function () {           
                return !(this.user.firstName != this.def.firstName
                    || this.user.lastName != this.def.lastName
                    || this.user.avatarUrl != this.def.avatarUrl)                

            },
        },
        methods: {
            changeText() {               
              
                
            },
            onSubmit() {
               this.$validator.validateAll().then((result) => {
                    if (result) {
                        this.$store.dispatch('UpdateUser', { data: this.user })
                            .then(() => {
                           
                            });
                    }
                });
            },           
            uploadFile(e) {  
                var test = /^image\//gm.test(e.type) && e.size < 512 * 1024;
                
                if (test) {
                    this.imageName = e.name
                    if (this.imageName.lastIndexOf('.') <= 0) {
                        return
                    }
                    const fr = new FileReader()
                    fr.readAsDataURL(e)
                    fr.addEventListener('load', () => {
                        this.user.avatarUrl = fr.result
                        this.user.avatarImgType = e.name.match(/.(jpg|png|gif)$/gm)[0]
                    })
                }               
            },     
        },
        beforeMount:  function () {
                var res=this.$store.state.authUser;
                this.user.firstName = res.firstName;
                this.user.lastName = res.lastName;
                this.user.avatarUrl = res.avatarUrl;
                this.def.firstName = res.firstName;
                this.def.lastName = res.lastName;
                this.def.avatarUrl = res.avatarUrl;
        }

    }
</script>
<style>
</style>
