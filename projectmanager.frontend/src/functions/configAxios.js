import Vue from 'vue'
import Axios from 'axios'

export class ConfigAxios {
	constructor() {

		Axios.defaults.baseURL = process.env.VUE_APP_ROOT_API_SHARP + '/api/'
		Axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'
		Axios.defaults.headers.common['Access-Control-Expose-Headers'] = 'Content-Length'
		Axios.defaults.headers.common['Access-Control-Allow-Credentials'] ='true'
		Axios.defaults.headers.common['Content-Type'] ='application/json'
		Axios.defaults.headers.common['charset'] = 'utf-8'
		Axios.defaults.crossDomain = true

		Vue.prototype.$http = Axios
      
		if (window.isDebug)
			console.log('Caminho da API:', Axios.defaults.baseURL)
	}
}