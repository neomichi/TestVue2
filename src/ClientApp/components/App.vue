<template>
    <div>

        <loginOrRegister></loginOrRegister>

        <h1>Работает</h1>

        <router-link to="/">Админка</router-link>
        <router-link to="/messages">Сообщения</router-link>
        <router-view></router-view>
       

    </div>
</template>
<script>

    import loginOrRegister from './LoginOrRegister.vue';
  
    import Vue from 'vue'
    
    export default {
       
            data: {
                message: 'Привет, Vue!'
            },
            components: {
                loginOrRegister: loginOrRegister
            },
        }
</script>