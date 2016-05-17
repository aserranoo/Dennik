(function () {
    'use strict';

    angular
        .module('app')
        .controller('modal', modal);

    modal.$inject = ['$location', '$uibModalInstance', 'datacontext', 'items'];

    function modal($location, $uibModalInstance, datacontext, items) {
        /* jshint validthis:true */
        var vm = this;
        vm.cancel = cancel;
        vm.ok = ok;
        vm.title = 'modal';                
        vm.registro = {};      
       
        function cancel() {            
            $uibModalInstance.dismiss(vm.dates);                
        }
        function ok() {
            console.log(items);
            var evento = new Evento(items.start, items.end, vm.registro);
            console.log(evento);
            $uibModalInstance.close(vm.registro);            
        }

        function Evento(start, end, evento) {
            this.start = start;
            this.end = end;
            this.evento = evento;
        }
    }
})();
