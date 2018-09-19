<template>
    <div>
        <v-container fluid>
            <v-layout row wrap>
                <v-flex xs12>
                    <h2>Наверное одна из очень не многочисленных ,совестких, песен мне нравится</h2>                   
                </v-flex>
            </v-layout> 
        </v-container>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                id: this.$route.params.id,
            }
        },
    }
</script>
<style>
</style>
