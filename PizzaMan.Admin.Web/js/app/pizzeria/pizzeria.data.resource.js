angular.module('app').factory('PizzeriaDataResource', function (apiUrl, $http) {
    function getPizzeriaMostReviews() {
        return $http.get(apiUrl + 'pizzerias/mostreviews')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPizzeriaHighestRated() {
        return $http.get(apiUrl + 'pizzerias/highestrated')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getPizzeriaMostReviews: getPizzeriaMostReviews,
        getPizzeriaHighestRated: getPizzeriaHighestRated
    };

});

