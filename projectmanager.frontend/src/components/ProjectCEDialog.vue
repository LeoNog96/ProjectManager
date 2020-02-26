<template>
    <div>
        <md-dialog class="teste" :md-active.sync="showDialog">
       
            <md-dialog-title>Projetos</md-dialog-title>
            <form novalidate class="md-layout" @submit.prevent="submitform()">

                <md-dialog-content>
                    <div class="md-layout md-gutter">
                        <div class="md-layout-item md-small-size-100">
                            <md-field :class="getValidationClass('name')">
                                <label for="project-name">Nome do Projeto</label>
                                <md-input name="project-name" id="project-name" v-model="form.name" :disabled="sending" />
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
    name: 'ProjectCEDialog',
    
    mixins: [validationMixin],
    
    props:{
        project: Object,
        showDialog: Boolean
    },

    data: () => ({
      form: {
        name: null,
        initialDate: null,
        finalDate: null,
      },
      projectSaved: false,
      sending: false,
      error: false,
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
        },

        init(){
            if (this.project.id !== 0){
                this.form.name = this.project.name
                this.form.initialDate = new Date(this.project.initialDate)
                this.form.finalDate = new Date(this.project.finalDate)
            }            
        },

        save(){
            this.sending = true
            
            let obj = {
                name: this.form.name,
                initialDate: new Date(this.form.initialDate).toISOString(),
                finalDate: new Date(this.form.finalDate).toISOString(),
                percentComplete: 0,
            }
            console.log(obj)
            this.$http.post('projects', obj)
                .then(response => 
                {
                    if(response.status === 201){
                        this.projectSaved = true
                    }
                })
                .catch(() =>
                {
                    this.projectSaved = false
                    this.error = true
                
                })
                .finally(() =>
                {
                    this.clearForm()
                    this.sending = false
                    this.$emit('close-task-dialog',{showDialog: false, projectSaved: this.projectSaved, error: this.error})
                })
        },

        update(){
            this.sending = true
            
            let obj = {
                id: this.project.id,
                name: this.form.name,
                initialDate: this.form.initialDate,
                finalDate: this.form.finalDate,
                percentComplete: this.project.percentComplete,
                late: this.project.late,
                removed : false,
            }

            this.$http.put('projects', obj)
                .then(response => 
                {
                    if(response.status === 204){
                        this.projectSaved = true
                    }
                })
                .catch(() =>
                {
                    this.projectSaved = false
                    this.error = true
                
                })
                .finally(() =>
                {
                    this.sending = false
                    this.$emit('close-task-dialog',{showDialog: false, projectSaved: this.projectSaved, error: this.error})
                })
        }, 

        close(){
            this.$emit('close-task-dialog',{showDialog: false, projectSaved: false, error: false})
        },

        submitform(){
            this.$v.$touch()

            if (!this.$v.$invalid) {
                
                if(this.project.id === 0)
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