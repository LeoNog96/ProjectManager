<template>
  <div>
    <md-empty-state
        md-icon="devices_other"
        :md-label="label"
        :md-description="description"
    >
        <md-button class="md-primary md-raised">{{label}}</md-button>
    </md-empty-state>
  </div>
</template>

<script>
  export default {
    name: 'EmptyState',
    props:{
        label: String,
        description: String
    }
  }
</script>