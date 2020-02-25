import Vue from 'vue'
import Router from 'vue-router'
import Projects from './views/Projects.vue'
import Activities from './views/Activities.vue'
Vue.use(Router)

export default new Router({
	mode: 'history',
	base: process.env.BASE_URL,
	routes: [
		{
			path: '/',
			name: 'home',
			component: Projects
		},
		{
			path: '/projeto/:id/atividades',
			name: 'atividades',
			component: Activities
		},
	]

})
