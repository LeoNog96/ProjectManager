<template>
    <div>
        <div>
            <h3>Projetos</h3>
            <md-divider ></md-divider>
        </div>
        
        <md-progress-bar v-if="showSpinner" md-mode="query"></md-progress-bar>

        <div v-if="listProject.length === 0">
            <EmptyState :label="label" :description="desc" @new-from-empty="newItem"></EmptyState>
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
        },
        showSpinner: false,
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
        
        loadListCallBack(response){
            this.listProject = response.data
        },
        
        callBackError(err){
			console.log(err.response.data.message)
        },

        callbackLoadTimes(){
			this.showSpinner = false
		},
        
        loadList() {
            this.showSpinner = true
            this.$http.get('projects/all')
				.then(this.loadListCallBack)
				.finally(this.callbackLoadTimes)
				.catch(this.callBackError)
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