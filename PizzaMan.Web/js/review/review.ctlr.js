angular.module('app').controller('ReviewController', function ($scope, ReviewResource, PizzeriaResource, $stateParams, AspectResource) {

    $scope.pizzeria = PizzeriaResource.get({ pizzeriaId: $stateParams.id });

    $scope.newReview = {};
    $scope.newReview.PizzeriaId = $stateParams.id;
    $scope.newReview.AspectRatings = AspectResource.query();

    $scope.createReview = function () {
        ReviewResource.save($scope.newReview, function () {
            $scope.newReview = {};
            alert('Review Added');
            location.replace('#/home/find/name=' +  $scope.pizzeria.PizzeriaName);
        });
    };

    });