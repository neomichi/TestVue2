    <template>     
        <div>
            <h1>Car Edit  {{id}} </h1>
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
