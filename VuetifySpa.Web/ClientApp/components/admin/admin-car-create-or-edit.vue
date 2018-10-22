<template>
    <div>
        <v-container fluid fill-height>
            <v-layout align-center justify-center>
                <v-flex xs12>
                    <h1> Car Edit  {{id}} {{createOrEdit}}</h1> 
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
                createOrEdit: this.$route.params.createOrEdit
            }
        },
        computed: {

        },
        beforeMount: function () {
                       
        },
        methods: {       

        }
    }
</script>
<style>   
</style>
