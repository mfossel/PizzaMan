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

    return {
        getUsersMostReviews: getUsersMostReviews,
        getUsersMostPhotos: getUsersMostPhotos
    };

});

