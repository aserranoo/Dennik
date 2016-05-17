(function () {
    'use strict';

    angular
        .module('common.services')
        .factory('provedorResource', provedorResource);

    provedorResource.$inject = ['$resource', 'appSettings'];

    function provedorResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/Provedor/:id")
    }
})();