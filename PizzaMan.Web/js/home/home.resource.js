angular.module('app').factory('HomeResource', function (apiUrl, $http) {
    function getCurrentUser(i) {
        return $http.get(apiUrl + 'accounts/currentuser')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getCurrentUser: getCurrentUser
    };

});

