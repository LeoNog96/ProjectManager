<template>
    <div>
        <md-dialog class="teste" :md-active.sync="showDialog">
       
            <md-dialog-title>Atividades</md-dialog-title>
            <form novalidate class="md-layout" @submit.prevent="submitform()">

                <md-dialog-content>
                    <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <md-field :class="getValidationClass('name')">
                                <label for="activity-name">Nome da Atividade</label>
                                <md-input name="activity-name" id="activity-name" v-model="form.name" :disabled="sending" />
                                <span class="md-error" v-if="!$v.form.name.required">O nome do projeto é requerido</span>
                            </md-field>
                        </div>
                    </div>

                    <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <div :class="getValidationClass('initialDate')">
                                <md-datepicker v-model="form.initialDate" md-immediately >
                                    <label>Data de Inicio</label>
                                </md-datepicker>
                                <span class="l-error" v-if="!$v.form.initialDate.required">A data inicial do projeto é requerida</span>
                            </div>
                        </div>
                    </div>

                    <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <div :class="getValidationClass('finalDate')">
                                <md-datepicker v-model="form.finalDate" md-immediately >
                                    <label>Data de Fim</label>
                                </md-datepicker>
                                <span class="l-error" v-if="!$v.form.finalDate.required">A data final do projeto é requerida</span>
                            </div>
                        </div>
                    </div>

                     <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <md-field :class="getValidationClass('finished')">
                                <label for="finished">Finalizada?</label>
                                <md-select name="finished" id="finished" v-model="form.finished" md-dense :disabled="sending">
                                    <md-option :value="true">Sim</md-option>
                                    <md-option :value="false">Não</md-option>
                                </md-select>
                                <span class="md-error" v-if="!$v.form.finished.required">A situação da atividade é requerida</span>
                            </md-field>
                        </div>
                    </div>
                </md-dialog-content>              

            </form>
            <md-dialog-actions>
                <md-button class="md-primary" :disabled="sending" @click="submitform">Salvar</md-button>
                <md-button class="md-primary" @click="close">Fechar</md-button>
            </md-dialog-actions>
            <md-progress-bar md-mode="indeterminate" v-if="sending" />
        </md-dialog>
       
    </div>
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required } from 'vuelidate/lib/validators'

export default {
    name: 'ActivityCEDialog',
    
    mixins: [validationMixin],
    
    props:{
        projectId:Number,
        showDialog: Boolean,
        activity: Object
    },

    data: () => ({
      form: {
        name: null,
        initialDate: null,
        finalDate: null,
        finished: false,
      },
      activitySaved: false,
      sending: false,
    }),

    validations: {
      form: {
        name: {
          required
        },
        initialDate: {
          required
        },
        finalDate: {
          required
        },
        finished: {
            required
        }
      }
    },

    methods:{
        getValidationClass (fieldName) {
            const field = this.$v.form[fieldName]

            if (field) {
                return {
                    'md-invalid': field.$invalid && field.$dirty
                }
            }
        },

        clearForm () {
            this.$v.$reset()
            this.form.name = null
            this.form.initialDate = null
            this.form.finalDate = null
            this.form.finished = false
        },

        init(){
            if (this.activity.id !== 0){
                this.form.name = this.activity.name
                this.form.initialDate = new Date(this.activity.initialDate)
                this.form.finalDate = new Date(this.activity.finalDate)
                this.form.finished = this.activity.finished
            }    
        },

        save(){
            this.sending = true

            let obj = {
                name: this.form.name,
                initialDate: new Date(this.form.initialDate).toISOString(),
                finalDate: new Date(this.form.finalDate).toISOString(),
                finished: this.form.finished,
                projectId: this.projectId
            }
            
            window.setTimeout(() => {
                this.activitySaved = true
                this.sending = false
                this.clearForm()
                this.$emit('close-task-dialog',{showDialog: false, activitySaved: this.activitySaved})
                }, 1500
            )
            console.log(obj);
        },

        update(){
            this.sending = true
            
            let obj = {
                id: this.activity.id,
                name: this.form.name,
                initialDate: new Date(this.form.initialDate).toISOString(),
                finalDate: new Date(this.form.initialDate).toISOString(),
                finished: this.form.finished,
                projectId: this.projectId
            }
            
            window.setTimeout(() => {
                this.activitySaved = true
                this.sending = false
                this.$emit('close-task-dialog',{showDialog: false, activitySaved: this.activitySaved})
                }, 1500
            )
            console.log(obj);
        }, 

        close(){
            this.$emit('close-task-dialog',{showDialog: false, activitySaved: false})
        },

        submitform(){
            console.log('obj');
            this.$v.$touch()

            if (!this.$v.$invalid) {
                
                if(this.activity.id === 0)
                    this.save()
                else
                    this.update()
            }
        }
    },
    mounted(){
        this.init()
    }
}
</script>

<style lang="scss" scoped>
  .md-dialog {
      width: 768px;
      display:inline-flex !important;
  }
  .l-error{
      color:red;
  }
</style>