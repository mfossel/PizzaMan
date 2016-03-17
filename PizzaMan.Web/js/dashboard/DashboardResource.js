angular.module('app').factory('DashboardResource', function (apiUrl, $http) {
    function getLatestReview() {
        return $http.get(apiUrl + 'reviews/latest')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getLatestReview: getLatestReview
    };

});

