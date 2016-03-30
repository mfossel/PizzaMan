angular.module('app').controller('DashboardController', function ($scope, DashboardResource) {
    function activate() {
        DashboardResource.getPizzeriasCount().then(function (response) {
            $scope.pizzeriasCount = response;
        });

        DashboardResource.getPhotosCount().then(function (response) {
                $scope.photosCount = response;
        });
            
        DashboardResource.getUsersCount().then(function (response) {
                    $scope.usersCount = response;
        });

        DashboardResource.getReviewsCount().then(function (response) {
                        $scope.reviewsCount = response;

        });

        DashboardResource.getMostRecentPhoto().then(function (response) {
            $scope.recentPhoto = response;

        });


    }

    activate();
});