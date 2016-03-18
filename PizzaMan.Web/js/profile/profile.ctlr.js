angular.module('app').controller('ProfileController', function ($scope, ProfileResource) {
    function activate() {
        ProfileResource.getCurrentUser().then(function (response) {
            $scope.user = response;
        });

        ProfileResource.getReviewsForUser().then(function (response) {
            $scope.reviews = response;
        });
      
    }


    activate();

});