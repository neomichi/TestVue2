    <template>     
        <div>
            <h2>user messages</h2>
            <v-container fluid fill-height>
                <v-layout align-center justify-center>

                    <div id="content">
                        <div id="column1">
                            <div class="message" v-for="item in GetMessages" :key="item.id">
                                <div class="avatar">
                                    <v-avatar> <img :src="item.fromAvatarUrl" alt="аватар"
                                    aspect-ratio="1" class="grey lighten-2 "/></v-avatar>
                                </div>
                                <div class="text">
                                    <div class="vt">
                                        <div><span>{{item.fromFio}}</span></div>
                                        <div>2</div>
                                        <div>3</div>
                                    </div>                                
                                </div>
                            </div>
                           
                        </div>
                        <div id="column2">

                            Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        </div>
                    </div>

                    <!--<v-flex style="width:36vw;height:100%;">
                        <v-card color="white" style="height:8.11vh;border:solid 1px #ebeef3;color:black;" v-for="item in GetMessages">
                            <div style="align-items:center;justify-content:center;">
                                <div style="padding:15px;">
                                    <v-img :src="item.fromAvatarUrl" max-height="4.6vw" max-width="4.6vw" alt="аватар"
                                           aspect-ratio="1" class="grey lighten-2"></v-img>
                                </div>
                                <div>
                                    {{ item.title }}
                                </div>
                            </div>
                        </v-card>

                    </v-flex>





                    <v-flex style="width:64vw;height:100%;border:solid 1px #ebeef3">
                        <v-card>

                        </v-card>
                    </v-flex>-->
                </v-layout>
            </v-container>
        </div>

</template>
<script>
    export default {
        data() {
            return {               
              
                
              
            }
         
        },
        computed: {
            GetMessages() {
                console.log(this.$store.state.messages.data);
               return this.$store.state.messages.data;
            }
        },
    }
</script>
<style>
    .message {
        border: solid 1px #ebeef3;
        height:10.66vh;
        display:flex;
        justify-content:center;
        align-items:center;
    }
    .avatar {
       margin:auto 1.51vh;
        width: 4.44vw; 
    }
    .text {
        width: 78.24vh;
        border: solid 1px black;
    
    }
    div#column1{
        width:35.55vw;  
        border: solid 1px black;
    }
    div#column2 {
        width: 57.77vw;
        border: solid 1px black;
        height:200px;
    }
    div#content {
        display: flex;
        align-content: flex-start;
        justify-content: center;
        flex-wrap:wrap;

    }
    .vt {
        display: flex;
       
        flex-direction: column;
        justify-content: space-around;
        border: solid 1px black;
        
    }
        .vt div {
            height: 35px;
        }

</style>
