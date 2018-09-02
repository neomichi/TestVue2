<template>
    <div>
        <h1>Курс биткойна к usd</h1>

        <p>пример</p>

        <p v-if="!btc"><em>Loading...</em></p>

        <p  v-if="btc">{{btc}}</p>
        

    </div>
  
    

</template>

<script>
export default {
    data() {
        return {
            btc: null
        }
    },
    methods: {
    },
    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        try {
            let response = await this.$http.get('/api/SampleData/getprice')
            console.log(response.data);
            this.btc = response.data;
        } catch (error) {
            console.log(error)
        }
        // Old promise-based approach
        //this.$http
        //    .get('/api/SampleData/WeatherForecasts')
        //    .then(response => {
        //        console.log(response.data)
        //        this.forecasts = response.data
        //    })
        //    .catch((error) => console.log(error))*/
    }
}
</script>

<style>
</style>
