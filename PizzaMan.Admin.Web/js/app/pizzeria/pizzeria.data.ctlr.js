angular.module('app').controller('PizzeriaDataController', function ($scope, PizzeriaDataResource) {

    function activate() {
        PizzeriaDataResource.getPizzeriaMostReviews().then(function (response) {
            $scope.pizzeriaMostReviews = response;


        });

        PizzeriaDataResource.getPizzeriaHighestRated().then(function (response) {
            $scope.pizzeriaHighestRated = response;


        });


    }

    activate();

});