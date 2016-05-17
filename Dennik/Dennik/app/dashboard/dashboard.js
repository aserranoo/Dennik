(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'uiCalendarConfig', '$compile', '$scope', '$uibModal', '$log', dashboard]);

    function dashboard(common, datacontext, uiCalendarConfig, $compile, $scope, $uibModal, $log) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var vm = this;
        vm.uiConfig = {
            calendar: {
                height: 450,
                editable: true,
                selectable: true,
                selectHelper: true,
                lang: "es",
                defaultAllDayEventDuration: {
                    days: 0
                },
                header: {
                    left: 'month agendaWeek agendaDay',
                    center: 'title',
                    right: 'today prev,next'
                },
                select: selected,
                eventRender: render,
                selectOverlap: function (event) {
                    return ! event.block;
                }
            },
            event: {
                eventSources: []
            }
        };
        vm.title = 'Dashboard';
        activate();

        function activate() {
            common.activateController(controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function alertEventOnClick() {
            //console.log("holaday");
        }       
        function selected(start, end, jsEvent, view) {
            var fecha = new fechas(start, end);            
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/app/dashboard/modal.html",
                controller: 'modal as vm',
                size: "lg",
                resolve: {
                    items: function () {
                        return fecha
                    }
                }
            });
            modalInstance.result.then(function (selectedItem) {
                $("#calendar").fullCalendar('addEventSource', [{
                    title: "prueba",
                    start: start,
                    end: end,
                    block: true,
                    description: 'This is a cool event'
                }, ]);
                $("#calendar").fullCalendar("unselect");
            }, function (dates) {
                $("#calendar").fullCalendar("unselect");
                $log.info('Modal dismissed at: ' + new Date());
            });
        }
        function fechas(start, end) {
            this.start = start;
            this.end = end;
        }
        function render(event, element, view) {
            element.attr({
                'tooltip': event.title,
                'tooltip-append-to-body': true
            });
            $compile(element)($scope);
        }
    }
})();