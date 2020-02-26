<template>
    <div>
        <md-button class="md-icon-button md-primary" @click="edit">
            <md-icon>edit</md-icon>
            <md-tooltip md-direction="bottom">Editar</md-tooltip>
        </md-button>
        <ActivityCEDialog :activity="item" 
            :projectId="item.projectId" 
            :showDialog="this.showDialog"
            @close-task-dialog="activityDialogManager" 
        >
        </ActivityCEDialog>
    </div>
</template>

<script>
import ActivityCEDialog from './ActivityCEDialog'
export default {
    name: "EditActivityInTable",

    components:{ActivityCEDialog},

    props:{
        item: Object
    },

    data:()=>({
        showDialog: false,
    }),

    methods:{
        activityDialogManager(obj){
            this.showDialog = obj.showDialog
            this.$emit('edit', obj)
        },
        edit(){
            this.showDialog = true
        }
    }
}
</script>

<style>

</style>