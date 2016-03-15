angular.module('app').factory('FindResource', function (apiUrl, $http) {
    function getPizzeriaByZip(zip) {
        return $http.get(apiUrl + 'pizzerias/zip=' + zip)
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPizzeriaByCity(city) {
        return $http.get(apiUrl + 'pizzerias/city=' + city)
                    .then(function (response) {
                        return response.data;
                    });
    }

    function getPizzeriaByName(name) {
        return $http.get(apiUrl + 'pizzerias/name=' + name)
                    .then(function (response) {
                        return response.data;
                    });
    }

    return {
        getPizzeriaByZip: getPizzeriaByZip,
        getPizzeriaByCity: getPizzeriaByCity,
        getPizzeriaByName: getPizzeriaByName
    };

});

