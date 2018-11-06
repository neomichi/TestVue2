<template>
    <div>
        <h1>Car Edit  {{car.id}}     {{car.title}} </h1>
    </div>
</template>
<script>
    import Vue from 'vue'
    import { HasEmptyJson } from "../app.js"
    export default {
        data() {
            return {
                car: {
                    id: this.$route.params.id,
                    title: this.$route.params.title
                },
            }
        },
        computed: {
        },
        mounted: function () {

            if (this.car.id == undefined) {
                this.$store.subscribe((UPDATE_CARS_STATUS, state) => {                   
                    var carData = this.$store.getters.GetCarByFilter("title", this.car.title);
                    if (HasEmptyJson(carData)) {
                        return this.$router.push({ name: 'home' })
                    } else {
                        this.car = carData;
                    }
                });
             }
        }
    }

</script>
<style>
</style>
