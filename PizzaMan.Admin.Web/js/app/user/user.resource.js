angular.module('app').factory('UserResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'users/:userId', { submissionId: '@UserId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});