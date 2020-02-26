<template>
    <div>
        <md-table v-model='activities' md-sort='initialDate' md-sort-order='asc' md-card>

            <md-table-row slot='md-table-row' slot-scope='{ item }'>
                
                <md-table-cell md-label='ID' md-numeric>
                    {{ item.id }}
                </md-table-cell>

                <md-table-cell md-label='Nome'>
                    {{ item.name }}
                </md-table-cell>

                <md-table-cell md-label='Data Inicial'>
                    {{ convertDate(item.initialDate) }}
                </md-table-cell>
                
                <md-table-cell md-label='Data Final'>
                    {{ convertDate(item.finalDate) }}
                </md-table-cell>
                
                <md-table-cell md-label='Finalizada?'>
                    {{ convertExpresionBool(item.finished) }}
                </md-table-cell>

                <md-table-cell md-label='Finalizar'>
                    <md-button class="md-icon-button md-primary" @click="finishActivity(item)" :disabled="item.finished">
                        <md-icon>done</md-icon>
                        <md-tooltip md-direction="bottom">Finalizar Atividade</md-tooltip>
                    </md-button>
                </md-table-cell>

                <md-table-cell md-label='Editar'>
                    <EditActivityInTable @edit="activityDialogManager" :item="item">
                    </EditActivityInTable>
                </md-table-cell>

                <md-table-cell md-label='Excluir'>
                    <md-button class="md-icon-button md-primary" @click="deleteActivity(item)">
                        <md-icon>delete</md-icon>
                        <md-tooltip md-direction="bottom">Excluir</md-tooltip>
                    </md-button>
                </md-table-cell>
            </md-table-row>			
        </md-table>

        <md-dialog-confirm
            :md-active.sync="activeDelete"
            md-title="Deseja Excluir a Atividade?"
            md-content=""
            md-confirm-text="Sim"
            md-cancel-text="Não"
            @md-cancel="onCancel"
            @md-confirm="deleteConfirmActivity" />
        <md-snackbar md-position="center" :md-duration="4000" :md-active.sync="showSnackbar" md-persistent>
            <span>Falha na operação</span>
            <md-button class="md-primary" @click="showSnackbar = false">Ok</md-button>
        </md-snackbar>
    </div>
</template>

<script>
import {utils} from '../mixins/utils'
import EditActivityInTable from './EditActivityInTable'

export default {
    name:"ActivityTable",

    mixins:[utils],
    
    components:{EditActivityInTable},

    props:{
        activities: Array
    },

    data:() =>({
        activeDelete: false,       
        toDelete: null,
        showSnackbar:false
    }),

    methods:{

        deleteConfirmActivity(){
            this.$http.delete('activities/'+this.toDelete.projectId+'/'+this.toDelete.id)
                .then(response =>
                {
                    if(response.status === 204){
                        this.$emit('refresh')
                    }
                })
                .catch(() =>
                {
                    this.showSnackbar = true
                
                })            
        },

        deleteActivity(item){
            this.toDelete = item
            this.activeDelete = true
        },

        finishActivity(item){
            item.finished = true,

            this.$http.put('activities', item)
                .then(response => 
                {
                    if(response.status === 204){
                        console.log('ok')
                    }
                })
                .catch(() =>
                {
                    this.showSnackbar = true
                
                })
                .finally(() =>
                {
                    this.$emit('refresh')
                })
            console.log(item)
        },

        onCancel(){

        },

        activityDialogManager(obj){            
            if(obj.activitySaved)
            {
                this.$emit('refresh')
            }
            if(obj.error){
                this.showSnackbar = true   
            }
        }
    }
}
</script>

<style>

</style>