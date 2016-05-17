
(function () {
    'use strict';

    angular
        .module('common.services')
        .factory("articuloResource", ["$resource","appSettings", articuloResource]);
    function articuloResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/Articulo/:id")
    }
})();
