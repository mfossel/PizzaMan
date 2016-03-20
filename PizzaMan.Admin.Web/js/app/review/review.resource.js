angular.module('app').factory('ReviewResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'reviews/:reviewId', { submissionId: '@ReviewId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});