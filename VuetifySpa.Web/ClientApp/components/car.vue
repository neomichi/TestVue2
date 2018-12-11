<template>
    <div>
        <h1>Car View  {{car.id}}  {{car.title}}    {{car.getImg}} </h1>
    {{car}}
        <div style="width:28.9vw">

            <v-card elevation-5>
                <div style="padding:2.34vh;">
                    <v-img :src="car.getImg" alt="аватар"
                           aspect-ratio="1.69" class="grey lighten-2"></v-img>  
                </div>
                <v-card-actions>
                </v-card-actions>
            </v-card>
        </div>

    
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
        methods: {
            getCar() {
                var title = this.$route.params.title;
                var a=this.$store.subscribe((UPDATE_CARS_STATUS, state) => {
                    this.car = this.$store.getters.GetCarByFilter("title", title);
                    console.log(this.car);
                    return this.car;
                });
                console.log(a);
               

                var carData = this.$store.getters.GetCarByFilter("title", title);
                //if (HasEmptyJson(carData)) {
                //    return this.$router.push({ name: 'home' })
                //} 
                this.car = carData;
                return carData;
            }
        },
        beforeUpdate: function () {
          
        },
        activated: function () {
            
        },
        mounted: function () {
            this.getCar();

        }
    }

</script>
<style>
</style>
