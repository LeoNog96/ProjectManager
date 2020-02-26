<template>

    <div>
        <!-- <div>
            <h3>Projeto</h3>
            <div>
                <div class="md-body-1">Nome: {{project.name}}</div>
                <div class="md-body-1">Data Inicial: {{convertDate(project.initialDate)}}</div>
                <div class="md-body-1">Data Final: {{convertDate(project.finalDate)}}</div>
                <div class="md-body-1">Percentual Completo: {{project.percentComplete}} %</div>
                <div class="md-body-1">Atrasado?: {{convertExpresionBool(project.late)}}</div>
            </div>
            <md-divider ></md-divider>
        </div> -->
        <div>
            <h3>Atividades</h3>
            <md-divider ></md-divider>
        </div>
        <md-progress-bar v-if="showSpinner" md-mode="query"></md-progress-bar>
        <div v-if="listActivities.length === 0 ||  showSpinner">
            <EmptyState :label="label" :description="desc"  @new-from-empty="newItem"></EmptyState>
        </div>
        <div v-else>
            <ActivityTable :activities="listActivities" @refresh="loadActivities"></ActivityTable>
            <SpeedDial @new-item="newItem" :bottomPosition="'md-bottom-right'"></SpeedDial>
        </div>
        <ActivityCEDialog :activity="activity" 
            :projectId="projectId" 
            :showDialog="this.showDialog" 
            @close-task-dialog="activityDialogManager" 
        ></ActivityCEDialog>
        <md-snackbar md-position="center" :md-duration="4000" :md-active.sync="showSnackbar" md-persistent>
            <span>Falha na operação</span>
            <md-button class="md-primary" @click="showSnackbar = false">Ok</md-button>
        </md-snackbar>
    </div>
  
</template>

<script>
import EmptyState from '../components/EmptyState'
import SpeedDial from '../components/SpeedDial'
import ActivityCEDialog from '../components/ActivityCEDialog'
import ActivityTable from '../components/ActivityTable'
import {utils} from '../mixins/utils'

export default {
    name:"Activities",

    components:{EmptyState, SpeedDial, ActivityTable, ActivityCEDialog},
    
    mixins:[utils],

    data: () => ({
        listActivities: [],
        label:'Criar a primeira atividade',
        desc: 'Crie a primeira atividade para acompanhar suas entregas',
        showDialog: false,
        showSpinner: false,
        activity:{
            "id":0
        },
        projectId: 0,
        project:{
            "id": 1,
            "name": "primeiro teste de teste do teste da teste",
            "initialDate": "2020-02-24T14:07:12.395Z",
            "finalDate": "2020-02-24T14:07:12.395Z",
            "percentComplete": 10,
            "late": false,
            "removed": true,
        },
        showSnackbar: false,
    }),

    methods:{
        newItem(){
            this.showDialog = true
        },

        activityDialogManager(obj){
            this.showDialog = obj.showDialog
            
            if(obj.activitySaved)
            {
                this.loadActivities()
            }
            
            if(obj.error){
                this.showSnackbar = true   
            }
        },
        
        loadListCallBack(response){
            this.listActivities = response.data
        },

        callBackError(err){
            console.log(err.response.data.message)
            this.listActivities = []
        },

        callbackLoadTimes(){
			this.showSpinner = false
		},

        loadActivities(){
            this.showSpinner = true
            
            this.$http.get('activities/all-by-project/'+this.$route.params.id)
				.then(this.loadListCallBack)
				.finally(this.callbackLoadTimes)
				.catch(this.callBackError)
        },

        init(){
            this.projectId = parseInt(this.$route.params.id)
            this.loadActivities()
        }
    },
    mounted(){
        this.init()        
    }
}
</script>

<style>

</style>