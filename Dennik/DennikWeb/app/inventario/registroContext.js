
(function () {
    'use strict';

    angular
        .module('app')
        .factory('registroContext', registroContext);

    registroContext.$inject = ["articuloResource", "$q"];

    function registroContext(articuloResource, $q) {        
        var deferredObject = $q.defer();
        var service = {
            $q: $q,
            getArticulos: getArticulos,
            saveArticulos: saveArticulos
        }

        return service;

        function getArticulos(articuloResource, Id) {                        
            articuloResource.query({
                id: Id                
            }, function (data) {
                console.log(data);
            })
            .$promise.then(function (data) {                
                deferredObject.resolve(data);
            }, function (err) {
                deferredObject.reject(err);
                console.log(err)
            });
        return deferredObject.promise;
        };

        function saveArticulos(articuloResource, articuloModel) {            
            articuloResource.save({Art: articuloModel})
            .$promise.then(function (data) {
                deferredObject.resolve(data);
            }, function (err) {
                deferredObject.reject(err);
            });
        return deferredObject.promise;
        };
    }
})();
