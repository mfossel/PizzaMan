angular.module('app').factory('DashboardResource', function (apiUrl, $http) {
    function getPizzeriaMostReviews() {
        return $http.get(apiUrl + 'pizzerias/mostreviews')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getUserMostReviews() {
        return $http.get(apiUrl + 'users/mostreviews')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getPizzeriaMostReviews: getPizzeriaMostReviews,
        getUserMostReviews: getUserMostReviews
    };

});

