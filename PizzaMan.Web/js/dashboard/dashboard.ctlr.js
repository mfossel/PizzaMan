angular.module('app').controller('DashboardController', function ($scope, DashboardResource) {

    function activate() {
        DashboardResource.getLatestReview().then(function (response) {
            $scope.review = response;
        });

    }

    activate();


});