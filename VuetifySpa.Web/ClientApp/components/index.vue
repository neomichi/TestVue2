<template>



</template>
<script>

    import Vue from 'vue'
    import metaInfo from 'vue-meta'
    Vue.component(metaInfo);

    export default {
        data() {
            return {
                metaInfo: {
                    title: '!работает',
                    titleTemplate: '%s - Bay!',
                    htmlAttrs: {
                        lang: 'ru',
                    }
                },
                items: [],

            }
        },
        computed: {


        },
        methods: {

        },

    }
</script>
<style scoped>

</style>
