angular.module('app').controller('ReviewDisplayController', function ($scope, ReviewDisplayResource, PizzeriaResource, $stateParams) {

    $scope.pizzeria = PizzeriaResource.get({ pizzeriaId: $stateParams.id });

    var id = $stateParams.id;

    function activate() {
        ReviewDisplayResource.getReviewsByPizzeria(id).then(function (response) {
            $scope.reviews = response;
        });

    }

    activate();

});