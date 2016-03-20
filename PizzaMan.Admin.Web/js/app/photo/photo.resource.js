angular.module('app').factory('PhotoResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'photos/:photoId', { submissionId: '@PhotoId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});