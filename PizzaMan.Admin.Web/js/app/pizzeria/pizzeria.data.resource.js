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

    function getAvgNumReviews() {
        return $http.get(apiUrl + 'pizzerias/avgnumberofreviews')
                    .then(function (response) {
                        return response.data;
                    });
    }

        function getAvgRating() {
            return $http.get(apiUrl + 'pizzerias/avgoverallrating')
                    .then(function (response) {
                        return response.data;
                    });
        }

        function getPercentDelivery() {
            return $http.get(apiUrl + 'pizzerias/percentdelivery')
                    .then(function (response) {
                        return response.data;
                    });
        }

        function getPercentAlcohol() {
            return $http.get(apiUrl + 'pizzerias/percentalcohol')
                    .then(function (response) {
                        return response.data;
                    });
        }

        function getPercentVegan() {
            return $http.get(apiUrl + 'pizzerias/percentvegan')
                    .then(function (response) {
                        return response.data;
                    });
        }

        function getPercentGlutenFree() {
            return $http.get(apiUrl + 'pizzerias/percentglutenfree')
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
        getPizzeriaOldest: getPizzeriaOldest,
        getAvgNumReviews: getAvgNumReviews,
        getAvgRating: getAvgRating,
        getPercentDelivery: getPercentDelivery,
        getPercentAlcohol: getPercentAlcohol,
        getPercentGlutenFree: getPercentGlutenFree,
        getPercentVegan: getPercentVegan
    };

});

