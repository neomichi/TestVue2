<template>
   

                    <v-flex xs12 sm8 md6>
                        <v-card class="elevation-12">
                            <v-toolbar dark color="primary">
                                <v-toolbar-title>Форма входа</v-toolbar-title>
                                <v-spacer></v-spacer>                                
                            </v-toolbar>
                            <v-card-text>
                                <v-form>
                                    <v-text-field prepend-icon="person" name="login" label="Логин" type="text"></v-text-field>
                                    <v-text-field prepend-icon="lock" name="password" label="Пароль" id="password" type="password"></v-text-field>
                                </v-form>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="primary">Войти</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-flex>
              

</template>

<script>
    export default {
        data() {
            return {
            }
        },
    }
</script>

<style>
</style>
