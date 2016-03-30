angular.module('app').factory('DashboardResource', function (apiUrl, $http) {
    function getPizzeriasCount() {
        return $http.get(apiUrl + 'pizzerias/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPhotosCount() {
        return $http.get(apiUrl + 'photos/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getUsersCount() {
        return $http.get(apiUrl + 'users/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getReviewsCount() {
        return $http.get(apiUrl + 'reviews/count')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getMostRecentPhoto() {
        return $http.get(apiUrl + 'photos/mostrecent')
                    .then(function (response) {
                        return response.data;
                    });
    }


    return {
        getPizzeriasCount: getPizzeriasCount,
        getPhotosCount: getPhotosCount,
        getReviewsCount: getReviewsCount,
        getUsersCount: getUsersCount,
        getMostRecentPhoto: getMostRecentPhoto
    };

});

