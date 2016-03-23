angular.module('app').controller('PizzeriaEditController', function ($scope, PizzeriaResource, $stateParams) {

 
    $scope.pizzeria = PizzeriaResource.get({ pizzeriaId: $stateParams.id })


    $scope.savePizzeria = function () {
        $scope.pizzeria.$update(function () {
            alert('save successful')
        }
          );
    }


});

