<template>
  <div>
    <md-empty-state
        md-icon="assignment"
        :md-label="label"
        :md-description="description"
    >
        <md-button class="md-primary md-raised" @click="newFromEmpty">{{label}}</md-button>
    </md-empty-state>
  </div>
</template>

<script>
  export default {
    name: 'EmptyState',
    props:{
        label: String,
        description: String
    },

    methods:{
      newFromEmpty(){
        this.$emit('new-from-empty')
      }
    }
  }
</script>