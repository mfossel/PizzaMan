angular.module('app').controller('PizzeriaController', function ($scope, PizzeriaResource) {

    function activate() {
        $scope.pizzerias = PizzeriaResource.query();
    }

    activate();
});