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

    function getPizzeriaHighestRatedDelivery() {
        return $http.get(apiUrl + 'pizzerias/highestrateddelivery')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPizzeriaHighestRatedSitdown() {
        return $http.get(apiUrl + 'pizzerias/highestratedsitdown')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPizzeriaHighestRatedGlutenFree() {
        return $http.get(apiUrl + 'pizzerias/highestratedglutenfree')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPizzeriaOldest() {
        return $http.get(apiUrl + 'pizzerias/oldest')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getPizzeriaMostReviews: getPizzeriaMostReviews,
        getPizzeriaHighestRated: getPizzeriaHighestRated,
        getPizzeriaHighestRatedDelivery: getPizzeriaHighestRatedDelivery,
        getPizzeriaHighestRatedSitdown: getPizzeriaHighestRatedSitdown,
        getPizzeriaHighestRatedGlutenFree: getPizzeriaHighestRatedGlutenFree,
        getPizzeriaOldest: getPizzeriaOldest
    };

});

