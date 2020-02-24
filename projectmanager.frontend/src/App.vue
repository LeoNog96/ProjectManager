<template>
	<div id="principalApp" class="page-container md-layout-column">
		<md-toolbar class="md-primary">
			
			<md-button  class="md-icon-button" @click="showNavigation = !showNavigation">
				<md-icon>menu</md-icon>
			</md-button>

			<span class="md-title">Project Manager</span>
			
			<md-button  class="md-icon-button" to="/">
				<md-icon id="iconHome">home</md-icon>
			</md-button>

		</md-toolbar>

		<!-- Menu lateral esquerda (opcoes) -->
		<md-drawer
			:md-active.sync="showNavigation" 
			md-swipeable 
			class="buttons-menu-options">

			<md-toolbar class="md-transparent" md-elevation="0">
				<span class="md-title">Menu</span>
			</md-toolbar>

			<md-list id="routesMenu">
				
				<md-list-item>
				
					<md-button 
						to="/"
						@click.native="closeLeftMenu">
				
						<md-icon>schedule</md-icon>
				
						<span >Projetos</span>
					</md-button>
				</md-list-item>
			</md-list>
		</md-drawer>

		<md-content>
			<router-view></router-view>        
		</md-content>
	</div>
</template>


<script>
export default {
	
	name: 'app',
	
	data: () => ({
		showNavigation: false,
		showSidepanel: false,
		departament:null,
	}),
	
	methods:{
		
		closeLeftMenu(){
			this.showNavigation = !this.showNavigation
		},
		
		sync(){
			this.$http.get('sync')
			this.closeLeftMenu()
		},
	}
}
</script>

<style lang="scss">

	.buttons-menu-options {

		a, button {
			width: inherit;
		}

		.md-icon{
			margin-right: 10px !important;
		}

		.md-button .md-ripple {
			justify-content: left;
		}
	}

	.dc-datepicker > .md-icon.md-theme-default.md-icon-image svg{
		fill: var(--md-theme-default-primary) !important;
	}
</style>

<style lang="scss" scoped>

	.md-content {
		padding: 20px;
	}

	.text-notify{
		text-align: center;
	}

</style>


