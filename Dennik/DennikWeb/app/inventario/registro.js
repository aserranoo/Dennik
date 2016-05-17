(function () {
    'use strict';
    var controllerId = 'registro'
    angular
        .module('app')
        .controller(controllerId, registro);

    registro.$inject = ['$location', 'common', 'registroContext', 'articuloResource'];

    function registro($location, common, registroContext, articuloResource) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        /* jshint validthis:true */
        var vm = this;
        vm.articulos = {};
        var model = {
            Descripcion: "",
            Cantidad: 0,
            Bloqueado: false
        }
        vm.articulosModel = new articulo("", "", 1, false, model)
        vm.title = 'registro';
        vm.hideSpin = false;
        vm.registroArticulo = registroArticulos;
        activate();

        function activate() {
            common.activateController([], controllerId).then(function () {
                log('Inventario');
            });

            registroContext.getArticulos(articuloResource, "").then(function (data) {
                console.log(data);
                vm.articulos = data;
                vm.hideSpin = true;
            }, function (err) {
            });
        }

        function registroArticulos(articulosModel) {
            var art = new articulo("", articulosModel.Descripcion, articulosModel.Cantidad, articulosModel.Bloqueado, model)
            registroContext.saveArticulos(articuloResource, articulosModel).then(function (data) {
                console.log(data);
                vm.articulos.push(art)
            });
        }

        function articulo(ArticuloId, Descripcion, Cantidad, Bloqueado, model) {
            var models = model;
            this.ArticuloId = ArticuloId
            models.Descripcion = Descripcion;
            models.Cantidad = Cantidad;
            models.Bloqueado = Bloqueado;
            this.Art = models
        }
    }
})();
