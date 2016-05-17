(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', '$q', datacontext]);

    function datacontext(common, $http, $q) {
        var deferred = $q.defer();

        var service = {           
            guardarEvento: guardarEvento
        };

        return service;

        function guardarEvento(data){
            var evento = {
                
            }
        }
        function guardarStock(articuloDesc) {

        }
    }
})();