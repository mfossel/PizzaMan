angular.module('app').controller('PizzeriaController', function ($scope, PizzeriaResource) {

    function activate() {
        $scope.pizzerias = PizzeriaResource.query();
    }

    $scope.deletePizzeria = function (review) {
        pizzeria.$remove(function (data) {
            activate();
        })

    };

    activate();

});