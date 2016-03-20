angular.module('app').factory('PizzeriaResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'pizzerias/:pizzeriaId', { submissionId: '@PizzeriaId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});