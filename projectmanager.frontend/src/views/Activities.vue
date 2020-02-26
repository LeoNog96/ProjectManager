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
        <div v-if="listActivities.length === 0">
            <EmptyState :label="label" :description="desc"></EmptyState>
        </div>
        <div v-else>
            <ActivityTable :activities="listActivities"></ActivityTable>
            <SpeedDial @new-item="newItem" :bottomPosition="'md-bottom-right'"></SpeedDial>
        </div>
    </div>
  
</template>

<script>
import EmptyState from '../components/EmptyState'
import SpeedDial from '../components/SpeedDial'
import ActivityTable from '../components/ActivityTable'
import {utils} from '../mixins/utils'

export default {
    name:"Activities",

    components:{EmptyState, SpeedDial, ActivityTable},
    
    mixins:[utils],

    data: () => ({
        listActivities: [],
        label:'Criar a primeira atividade',
        desc: 'Crie a primeira atividade para acompanhar suas entregas',
        showDialog: false,

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
    }),

    methods:{
        newItem(){
            this.showDialog = true
        },

        loadActivities(){
            this.listActivities = [
                {
                    "id":1,
                    "name": "Criar a primeira atividade",
                    "initialDate":"2020-02-20T14:07:12.395Z",
                    "finalDate":"2020-02-24T14:07:12.395Z",
                    "finished":true,
                },
                {
                    "id":2,
                    "name": "teste1",
                    "initialDate":"2020-02-20T14:07:12.395Z",
                    "finalDate":"2020-02-24T14:07:12.395Z",
                    "finished":false,
                }
            ]
        }
    },
    mounted(){
        this.loadActivities()
        this.projectId = this.$route.params.id
    }
}
</script>

<style>

</style>