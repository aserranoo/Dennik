(function () {
    'use strict';

    angular
        .module('app')
        .factory('registroProvedoresContext', registroProvedoresContext);

    registroProvedoresContext.$inject = ['provedorResource','$q'];

    function registroProvedoresContext(provedorResource, $q) {
        var deferredObject = $q.defer();
        var service = {            
            getProvedores: getProvedores,
            saveProvedores: saveProvedores
        };

        return service;

        function getProvedores(provedorResource, id) {
            provedorResource.query({
                id: id
            })
            .$promise.then(function (data) {
                deferredObject.resolve(data);
            }, function (err) {
            });
            return deferredObject.promise;
        };

        function saveProvedores(provedorModel) {
            provedorResource.save(provedorModel)
            .$promise.then(function (data) {
                deferredObject.resolve(data);
            }, function (err) {
                deferredObject.reject(err);
            });
        return deferredObject.promise;
        }
    }
})();