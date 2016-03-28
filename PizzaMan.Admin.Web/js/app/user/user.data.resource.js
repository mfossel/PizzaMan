angular.module('app').factory('UserDataResource', function (apiUrl, $http) {
    function getUsersMostReviews() {
        return $http.get(apiUrl + 'users/mostreviews')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getUsersMostPhotos() {
        return $http.get(apiUrl + 'users/mostphotos')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getUsersAvgNumReviews() {
        return $http.get(apiUrl + 'users/avgnumberofreviews')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getUsersAvgNumPhotos() {
        return $http.get(apiUrl + 'users/avgnumberofphotos')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getUsers() {
        return $http.get(apiUrl + 'users/all')
                    .then(function (response) {
                        return response.data;
                    });
    }


    return {
        getUsersMostReviews: getUsersMostReviews,
        getUsersMostPhotos: getUsersMostPhotos,
        getUsersAvgNumPhotos: getUsersAvgNumPhotos,
        getUsersAvgNumReviews: getUsersAvgNumReviews,
        getUsers: getUsers
    };

});

