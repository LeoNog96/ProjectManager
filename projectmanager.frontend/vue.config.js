
module.exports = {
    
	productionSourceMap: false,
	
	configureWebpack: {
		devtool: 'source-map'
	},

	devServer: {
		host: '0.0.0.0',
		port: '7070'
	}

}