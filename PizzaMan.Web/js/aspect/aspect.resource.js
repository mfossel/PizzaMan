angular.module('app').factory('AspectResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/aspects/:aspectId', { submissionId: '@AspectId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});