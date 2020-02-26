<template>
    <div>
        <div>
            <h3>Projetos</h3>
            <md-divider ></md-divider>
        </div>
        <div v-if="listProject.length === 0">
            <EmptyState :label="label" :description="desc"></EmptyState>
        </div>
        <div v-else class="project-center">
            <ProjectCard class="project"
            v-for="item of listProject"
            @refresh="loadList"
            :key="item.id"
            :project="item">
            </ProjectCard>
            <SpeedDial @new-item="newItem" :bottomPosition="'md-bottom-right'"></SpeedDial>
        </div>
        <ProjectCEDialog @close-task-dialog="projectDialogManager" 
            :project="project" 
            :showDialog="showDialog"
        >
        </ProjectCEDialog>
        
    </div>
    
</template>

<script>
import ProjectCard from '../components/ProjectCard'
import EmptyState from '../components/EmptyState'
import SpeedDial from '../components/SpeedDial'
import ProjectCEDialog from '../components/ProjectCEDialog'

export default {
    name:'Project',
    components:{ProjectCard, EmptyState, ProjectCEDialog, SpeedDial},
    data: () =>({
        label:'Criar o primeiro projeto',
        desc: 'Crie o primeiro projeto para acompanhar suas entregas',
        showDialog: false,
        listProject:[],
        project:{
            "id":0
        }
    }),
    
    methods:{
        projectDialogManager(obj){
            this.showDialog = obj.showDialog
            if(obj.projectSaved)
            {
                this.loadList()
            }
        },
        
        newItem(){
            this.showDialog = true
        },

        loadList() {
            this.listProject = [
                {
                    "id": 1,
                    "name": "primeiro teste de teste do teste da teste",
                    "initialDate": "2020-02-24T14:07:12.395Z",
                    "finalDate": "2020-02-24T14:07:12.395Z",
                    "percentComplete": 10,
                    "late": false,
                    "removed": true,
                },
                {
                    "id": 2,
                    "name": "primeiro teste de teste do teste da teste",
                    "initialDate": "2020-02-24T14:07:12.395Z",
                    "finalDate": "2020-02-24T14:07:12.395Z",
                    "percentComplete": 10,
                    "late": false,
                    "removed": true,    
                },
                {
                    "id": 3,
                    "name": "primeiro teste de teste do teste da teste",
                    "initialDate": "2020-02-24T14:07:12.395Z",
                    "finalDate": "2020-02-24T14:07:12.395Z",
                    "percentComplete": 18,
                    "late": false,
                    "removed": true,
                }
            ]
        }
    },
    mounted(){
        this.loadList()
    }

}
</script>

<style lang="scss" scoped>
    .header{
        align-content: center !important;
    }
    .project-center{
       margin-inline-start: 10%
    }
    .project{  
        margin-block-start: 20px;
        display: inline-block;
        flex-direction: row;
    }
</style>