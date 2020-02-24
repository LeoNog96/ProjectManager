import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import 'material-design-icons/iconfont/material-icons.css'
import 'typeface-roboto/index.css'
import store from './vuex/store'
import { ConfigAxios } from './functions/configAxios'

Vue.use(VueMaterial)

Vue.material.locale.dateFormat= 'dd/MM/yyyy',
Vue.material.locale.days = ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sabádo'],
Vue.material.locale.shortDays= ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
Vue.material.locale.shorterDays= ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
Vue.material.locale.months= ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
Vue.material.locale.shortMonths= ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Aug', 'Set', 'Out', 'Nov', 'Dez'],
Vue.material.locale.shorterMonths= ['J', 'F', 'M', 'A', 'M', 'Ju', 'J', 'A', 'Se', 'O', 'N', 'D'],

new ConfigAxios()

Vue.config.productionTip = false


new Vue({
	router,
	store,
	render: h => h(App)
}).$mount('#app')
