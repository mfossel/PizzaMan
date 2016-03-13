angular.module('app').controller('SubmitController', function ($scope, SubmitResource) {

    $scope.createPizzeria = function () {
        SubmitResource.save($scope.newPizzeria, function () {
            $scope.newPizzeria = {};
        });
    };

});