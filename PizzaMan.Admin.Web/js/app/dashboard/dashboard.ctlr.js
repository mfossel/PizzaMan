angular.module('app').controller('DashboardController', function ($scope, DashboardResource) {

    function activate() {
        DashboardResource.getPizzeriaMostReviews().then(function (response) {
            $scope.pizzeriaMostReviews = response;


        });

        DashboardResource.getUserMostReviews().then(function (response) {
            $scope.userMostReviews = response;


        });


    }

    activate();

});