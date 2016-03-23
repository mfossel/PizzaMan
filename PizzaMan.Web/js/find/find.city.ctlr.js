angular.module('app').controller('FindCityController', function ($scope, FindResource, $stateParams) {

    var city = $stateParams.city;

    function activate() {
        FindResource.getPizzeriaByCity(city).then(function (response) {
            $scope.pizzerias = response;
            $scope.city = city;
        });

    }

    activate();

});