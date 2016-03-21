angular.module('app').factory('DashboardResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'reviews/:reviewId', { submissionId: '@ReviewId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});