(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                sub: false,
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/admin',
                sub: false,
                config: {
                    title: 'admin',
                    templateUrl: 'app/admin/admin.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/inventario',
                sub: false,
                config: {
                    title: 'inventario',
                    templateUrl: 'app/inventario/registro.html',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-lock"></i> Inventario<i class="fa fa-angle-double-right fa-fw fa-lg aria-hidden="true""></i>'
                    }
                }
            }, {
                url: '/provedores',
                sub: true,
                config: {
                    title: 'provedores',
                    templateUrl: 'app/provedores/registroProvedores.html',
                    settings: {
                        nav: 4,
                        content: '<i class="fa fa-user-plus"></i> Provedores<i class="fa fa-angle-double-right fa-fw fa-lg aria-hidden="true""></i>'
                    }
                },
                //url: '/provedores',
                //    config: {
                //        title: 'registro',
                //        //templateUrl: 'app/provedores/test.html',
                //        settings: {
                //            content: '<i class="fa fa-user-plus"></i> Registro'
                //        }
                //}
            }
        ];
    }
})();