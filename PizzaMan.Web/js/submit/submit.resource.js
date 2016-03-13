angular.module('app').factory('SubmitResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/pizzerias/:pizzeriaId', { submissionId: '@PizzeriaId' },
    {
        'update': {
            method: 'PUT'
        }
    });
});