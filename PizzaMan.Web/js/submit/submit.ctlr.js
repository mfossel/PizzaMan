angular.module('app').controller('SubmitController', function ($scope, PizzeriaResource) {

    $scope.createPizzeria = function () {
        PizzeriaResource.save($scope.newPizzeria, function () {
            $scope.newPizzeria = {};
            alert('Pizzeria Added');
        });
    };

});