angular.module('app').factory('PizzeriaResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'pizzerias/:pizzeriaId', { pizzeriaId: '@PizzeriaId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});