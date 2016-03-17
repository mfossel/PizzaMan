angular.module('app').factory('ReviewDisplayResource', function (apiUrl, $http) {
    function getReviewsByPizzeria(id) {
        return $http.get(apiUrl + 'reviews/pizzeriaId=' + id)
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getReviewsByPizzeria: getReviewsByPizzeria
    };

});

