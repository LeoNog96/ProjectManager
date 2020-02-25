<template>
    <div>
        <md-dialog-confirm
        :md-active.sync="active"
        :md-title="title"
        :md-content="content"
        md-confirm-text="Sim"
        md-cancel-text="Não"
        @md-cancel="onCancel"
        @md-confirm="onConfirm" />
  </div>
</template>

<script>
  export default {
    name: 'DialogConfirm',
    
    props:{
        title:String,
        content: String,
        active: Boolean
    },

    data: () => ({
    }),
    
    methods: {
      onConfirm () {
        this.$emit('confirm', true)
      },
      onCancel () {
        this.$emit('confirm', false)
      }
    }
  }
</script>