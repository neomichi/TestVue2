<template>
    <div>
        <v-container fluid grid-list-lg>
            <v-layout row wrap justify-center>
                <v-flex xs8 sm4 md3 lg2>
                    <v-card elevation-5 height="240">
                        <div style="padding:10px;">
                            <v-img max-height="200" alt="" src="https://cdn.vuetifyjs.com/images/cards/desert.jpg"
                                   aspect-ratio="1" class="grey lighten-2"></v-img>
                        </div>
                        <v-card-text>

                        </v-card-text>

                        <v-layout align-center justify-start fill-height row>
                            <v-card-actions>
                                <div>
                                    <!--<upload-btn color="primary" title="загрузить">
                                    </upload-btn>-->
                                </div>
                            </v-card-actions>
                        </v-layout>



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
                                              v-on:change="changeText(this)"
                                              required prepend-icon="email" name="user_firstName" label="Имя"></v-text-field>
                                <v-text-field v-model="user.lastName"
                                              v-validate="'required|min:3|max:60'"
                                              :error-messages="errors.collect('user_lastName')"
                                              autocomplete="off"
                                              data-vv-as="фамилия"
                                              v-on:change="changeText(this)"
                                              required prepend-icon="email" name="user_lastName" label="Фамилия"></v-text-field>
                            </v-card-text>

                            <v-card-actions>

                                <v-spacer></v-spacer>

                                <v-btn v-if="IsModification" type="submit" color="primary" :loading="loading" :disable="loading">Сохранить</v-btn>
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
    //import UploadButton from 'vuetify-upload-button';
    Vue.use(VeeValidate);
    export default {
        $_veeValidate: {
            validator: 'new'
        },
        //components: {
        //    'upload-btn': UploadButton
        //},
        data() {
            return {

                def: {
                    avatarUrl: '',
                    firstName: '',
                    lastName: '',
                },

                user: {
                    avatarUrl:'',                    
                    firstName: '',
                    lastName: '',
                    password: '',
                    id: this.$route.params.id
                },
            }
        },
        computed: {
            loading: function () {
                cache: false;
            },
            IsModification: function () {
                return true; //this.user.avatarUrl != this.dev.avatarUrl ||
                    //this.user.firstName != this.dev.firstName ||
                    //this.user.lastName != this.dev.lastName;
                
            },

        },
        methods: {
            changeText(el) {
                console.log(el)
            },
            onSubmit() {
                his.$validator.validateAll().then((result) => {
                    if (result) {
                        this.$store.dispatch(formName, { data: formData })
                            .then(() => {
                                this.$router.push({ name: 'home' });
                            });
                    }
                });
            }

        },
        //beforeMount: async function () {
        //    this.$store.getters.GetUserData.then((res) => {                
        //        this.user.firstName = res.data.firstName;
        //        this.user.lastName = res.data.lastName;
        //        //this.user.avatarUrl = res.data.avatarUrl;

        //        this.def.firstName = res.data.firstName;
        //        this.def.lastName = res.data.lastName;
        //       // this.def.avatarUrl = res.data.avatarUrl;
        //    });
           
        //}

    }
</script>
<style>
</style>
