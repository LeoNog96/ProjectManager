<template>

    <div>
        <h1>{{this.$route.params.id}}</h1>
         <div>
            <h3>Ativi</h3>
            <md-divider ></md-divider>
        </div>
        <div v-if="listActivities.length === 0">
            <EmptyState :label="label" :description="desc"></EmptyState>
        </div>
    </div>
  
</template>

<script>
import EmptyState from '../components/EmptyState'
// import SpeedDial from '../components/SpeedDial'

export default {
    name:"Activities",

    components:{EmptyState},

    data: () => ({
        listActivities: [],
        label:'Criar a primeira atividade',
        desc: 'Crie a primeira atividade para acompanhar suas entregas',
    })
}
</script>

<style>

</style>