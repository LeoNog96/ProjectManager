<template>
    <div class="card-expansion">
        <md-card :class="getClass()">
            <md-card-header>
                <div class="md-title">{{project.name}}</div>
                <div class="md-subhead">Completado: {{project.percentComplete}} %</div>
            </md-card-header>

            <md-card-expand>
                <md-card-actions md-alignment="space-between">
                    <div>
                        <md-button class="md-icon-button md-primary">
                            <md-icon>delete</md-icon>
                            <md-tooltip md-direction="bottom">Excluir</md-tooltip>
                        </md-button>
                        <md-button class="md-icon-button md-primary" @click="editProject">
                            <md-icon>edit</md-icon>
                            <md-tooltip md-direction="bottom">Editar</md-tooltip>
                        </md-button>
                        <md-button class="md-icon-button md-primary">
                            <md-icon>arrow_forward</md-icon>
                            <md-tooltip md-direction="bottom">Ir para</md-tooltip>
                        </md-button>
                    </div>

                    <md-card-expand-trigger>
                        <md-button class="md-icon-button md-primary">
                            <md-icon>keyboard_arrow_down</md-icon>
                        </md-button>
                    </md-card-expand-trigger>
                </md-card-actions>

                <md-card-expand-content>
                    <md-card-content>
                        <div class="md-body-1">Nome: {{project.name}}</div>
                        <div class="md-body-1">Data Inicial: {{convertDate(project.initialDate)}}</div>
                        <div class="md-body-1">Data Final: {{convertDate(project.finalDate)}}</div>
                        <div class="md-body-1">Percentual Completo: {{project.percentComplete}} %</div>
                        <div class="md-body-1">Atrasado?: {{convertExpresionBool(project.late)}}</div>
                    </md-card-content>
                </md-card-expand-content>
            </md-card-expand>
        </md-card>
        <ProjectCEDialog @close-task-dialog="projectDialogManager" 
            :project="project" 
            :showDialog="showDialog"
        >
        </ProjectCEDialog>
    </div>
</template>

<script>
import ProjectCEDialog from './ProjectCEDialog'
export default {
    name: 'ProjectCard',
    
    components:{ProjectCEDialog},

    props:{
        project: Object
    },

    data: () => ({
        showDialog: false,
    }),
    
    methods:{
        convertExpresionBool(expression){
            return expression ? 'Sim' : 'Não'
        },

        convertDate(date){
            let newDate = new Date(date)
            let day  = newDate.getDate().toString()
            let dayfF = (day.length == 1) ? '0' + day : day
            let month  = (newDate.getMonth()+1).toString()
            let monthF = (month.length == 1) ? '0' + month : month
            let yearF = newDate.getFullYear()

            return dayfF + '/' + monthF + '/' + yearF;
        },

        projectDialogManager(obj){
            this.showDialog = obj.showDialog
            if(obj.projectSaved)
            {
                this.$emit('refresh')
            }
        },

        editProject(){
            this.showDialog = true;
        },

        getClass()
        {
            return this.project.late ? 'isLate' : ''
        }
    }
}
</script>

<style lang="scss" scoped>

    .md-card {
        width: 320px;
        margin: 5px;
        display: inline-block;
        // flex-direction: row;
        vertical-align: top;
    }
    .isLate{
        color: red !important;
    }
</style>