angular.module('app').factory('FindResource', function (apiUrl, $http) {
    function getPizzeriaByZip(zip) {
        return $http.get(apiUrl + 'pizzerias/?zip=' + zip)
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getPizzeriaByZip: getPizzeriaByZip
    };

});

