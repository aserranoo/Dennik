(function () {
    'use strict';
    var controllerId = 'registro'
    angular
        .module('app')
        .controller(controllerId, registro);

    registro.$inject = ['$location','common']; 

    function registro($location, common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'registro';

        activate();

        function activate() {
            common.activateController([], controllerId)
               .then(function () { log('Inventario'); });
        }
    }
})();
