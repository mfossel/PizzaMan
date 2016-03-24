angular.module('app').factory('ReviewResource', function (apiUrl, $resource) {
    return $resource(apiUrl + 'reviews/:reviewId', { reviewId: '@ReviewId' },
    {
        'update': {
            method: 'PUT'
        }
    });

});