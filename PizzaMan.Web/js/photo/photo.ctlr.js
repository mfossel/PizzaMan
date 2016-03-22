angular.module('app').controller('PhotoController', function ($scope, PhotoResource, PizzeriaResource, $stateParams) {

    $scope.pizzeria = PizzeriaResource.get({ pizzeriaId: $stateParams.id });

    $scope.mySlides = ['http://localhost:49923/../../img/o.jpg', 'http://localhost:49923/../../img/photo-1453831210728-695502f9f795.jpg', 'http://localhost:49923/../../img/pizza-744405_960_720.jpg'];
});