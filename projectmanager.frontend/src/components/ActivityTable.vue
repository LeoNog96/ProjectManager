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
                        <md-tooltip md-direction="bottom">Excluir</md-tooltip>
                    </md-button>
                </md-table-cell>

                <md-table-cell md-label='Editar'>
                    <md-button class="md-icon-button md-primary" @click="editActivity(item)">
                        <md-icon>edit</md-icon>
                        <md-tooltip md-direction="bottom">Editar</md-tooltip>
                    </md-button>
                </md-table-cell>

                <md-table-cell md-label='Excluir'>
                    <md-button class="md-icon-button md-primary" @click="activeDelete = true">
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
            @md-confirm="deleteActivity" />
    </div>
</template>

<script>
import {utils} from '../mixins/utils'

export default {
    name:"ActivityTable",

    mixins:[utils],

    props:{
        activities: Array
    },

    data:() =>({
        activeDelete: false
    }),

    methods:{
        editActivity(item){
            console.log(item)
        },

        deleteActivity(item){
            console.log(item)
        },

        finishActivity(item){
            item.finished = true,
            console.log(item)
        },

        onCancel(){

        }
    }
}
</script>

<style>

</style>