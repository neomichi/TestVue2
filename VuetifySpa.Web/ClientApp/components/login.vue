<template>

    <v-container fluid fill-height>
        <v-layout align-center justify-center>
            <v-flex xs12 sm8 md6>
                <form id="LoginRegForm" @submit.prevent="onSubmit">
                    <v-card v-if="loginPage" class="elevation-12">
                        <v-toolbar dark color="primary">
                            <v-toolbar-title>Форма входа</v-toolbar-title>
                            <v-spacer></v-spacer>
                        </v-toolbar>
                        <v-card-text>
                            <v-form>
                                <v-text-field prepend-icon="email" 
                                           v-validate="'required|email'"   
                                           :error-messages="errors.collect('email')"
                                           data-vv-name="email"
                                           required       
                                           v-model="login.email" name="email" label="Email" type="text"></v-text-field>
                                <v-text-field prepend-icon="lock" 
                                               v-validate="'required|min:6|max:20'"   
                                           :error-messages="errors.collect('password')"
                                           data-vv-name="password"
                                           required   
                                              v-model="login.password" name="password" label="Пароль" type="password"></v-text-field>
                            </v-form>
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn v-on:click="loginPage=!loginPage" color="yellow">регистрация</v-btn>
                            <v-btn color="primary">войти</v-btn>
                        </v-card-actions>
                    </v-card>
                    <v-card v-if="!loginPage" class="elevation-12">
                        <v-toolbar dark color="primary">
                            <v-toolbar-title>Форма регистрации</v-toolbar-title>
                            <v-spacer></v-spacer>
                        </v-toolbar>
                        <v-card-text>
                            <v-form>
                                <v-text-field v-model="reg.email"
                                               v-validate="'required|email'"   
                                           :error-messages="errors.collect('email')"
                                           data-vv-name="email"
                                           required   prepend-icon="email" name="email" label="Email" type="text"></v-text-field>
                                <v-text-field v-model="reg.password" 
                                                v-validate="'required|min:6|max:20'"   
                                           :error-messages="errors.collect('password')"
                                           data-vv-name="password"
                                           required 
                                              prepend-icon="lock" name="password" label="Пароль" type="password"></v-text-field>
                                <v-text-field v-model="reg.repassword" 
                                              v-validate="'required|confirmed:password'"   
                                           :error-messages="errors.collect('repassword')"
                                           data-vv-name="repassword"
                                           required prepend-icon="lock" name="repassword" label="Повторите пароль" type="password"></v-text-field>
                            </v-form>
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn v-on:click="loginPage=!loginPage" color="yellow">войти</v-btn>
                            <v-btn color="primary">регистрация</v-btn>
                        </v-card-actions>
                    </v-card>
                </form>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    import Vue from 'vue'
    import VeeValidate from 'vee-validate'

    Vue.use(VeeValidate, { locale: 'ru' });
    //Validator.localize('ru', VeeValidateMessagesRu);

    export default {
        data() {
            return {
                loginPage: true,
                login: {
                    email: '',
                    password: '',
                },
                reg: {
                    email: '',
                    password: '',
                    repassword: '',                    
                },
            }
        },
        methods: {
            submit() {
                
            }
        }
    }
</script>

<style>
</style>
