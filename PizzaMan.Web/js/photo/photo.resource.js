angular.module('app').factory('PhotoResource', function (apiUrl, $http) {
    function getRecentPhotos() {
        return $http.get(apiUrl + 'photos/mostrecents')
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getRecentPhotos: getRecentPhotos
    };

});

