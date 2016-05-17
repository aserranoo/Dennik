(function () {
    'use strict';
    var controllerId = 'registroProvedores';
    angular
        .module('app')
        .controller(controllerId, registroProvedores);

    registroProvedores.$inject = ['$location', 'common', 'registroProvedoresContext', 'provedorResource'];

    function registroProvedores($location, common, registroProvedoresContext, provedorResoruce) {
        /* jshint validthis:true */
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var vm = this;
        vm.title = 'registroProvedores';

        vm.provedores = {};
        vm.hideSpin = false;
        vm.registroProvedor = vm.registroProvedor;
        activate();

        function activate() {
            common.activateController([], controllerId).then(function () {
                log('Provedores'); 
            });

            registroProvedoresContext.getProvedores(provedorResoruce, "").then(function (data) {
                vm.provedores = data;
                vm.hideSpin = true;
            }, function (err) {

            });
        }
    }
})();
