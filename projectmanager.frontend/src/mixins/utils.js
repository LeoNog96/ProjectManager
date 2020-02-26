export const utils = {
    methods: {

        convertDate(date){
            let newDate = new Date(date)
            let day  = newDate.getDate().toString()
            let dayfF = (day.length == 1) ? '0' + day : day
            let month  = (newDate.getMonth()+1).toString()
            let monthF = (month.length == 1) ? '0' + month : month
            let yearF = newDate.getFullYear()

            return dayfF + '/' + monthF + '/' + yearF;
        },

        convertExpresionBool(expression){
            return expression ? 'Sim' : 'Não'
        },
    }
}