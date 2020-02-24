<template>
    <div class="speeddial">
        <md-speed-dial :class="bottomPosition">
            <md-speed-dial-target class="md-primary">
                <md-icon>add</md-icon>
            </md-speed-dial-target>

            <md-speed-dial-content>
                <md-button class="md-icon-button" @click="newItem">
                    <md-icon>note</md-icon>
                    <md-tooltip md-direction="top">Novo</md-tooltip>
                </md-button>
            </md-speed-dial-content>
        </md-speed-dial>
    </div>
</template>

<script>
export default {
    name: 'SpeedDial',
    props:{
        bottomPosition: String
    },
    methods:{
        newItem(){
            this.$emit('new-item')
        }
    }
}
</script>

<style lang="scss" scoped>

</style>