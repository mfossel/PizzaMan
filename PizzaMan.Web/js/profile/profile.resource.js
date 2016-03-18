angular.module('app').factory('ProfileResource', function (apiUrl, $http) {
    function getCurrentUser() {
        return $http.get(apiUrl + 'accounts/currentuser')
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getReviewsForUser() {
        return $http.get(apiUrl + 'reviews/user')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getCurrentUser: getCurrentUser,
        getReviewsForUser: getReviewsForUser
    };

});

