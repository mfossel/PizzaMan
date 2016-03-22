angular.module('app').controller('PhotoController', function ($scope, PhotoResource, PizzeriaResource, $stateParams) {

    $scope.pizzeria = PizzeriaResource.get({ pizzeriaId: $stateParams.id });

});