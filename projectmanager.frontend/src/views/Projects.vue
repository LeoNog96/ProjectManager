<template>
  <div>
      <ProjectCard :project="project"></ProjectCard>
  </div>
</template>

<script>
import ProjectCard from '../components/ProjectCard'
export default {
    name:'Project',
    components:{ProjectCard},
    data: () =>({
        project:{
            "id": 0,
            "name": "primeiro teste de teste do teste da teste",
            "initialDate": "2020-02-24T14:07:12.395Z",
            "finalDate": "2020-02-24T14:07:12.395Z",
            "percentComplete": 10,
            "late": false,
            "removed": true,
        }
    })

}
</script>

<style>

</style>