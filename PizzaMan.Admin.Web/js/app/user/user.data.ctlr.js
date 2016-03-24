angular.module('app').controller('UserDataController', function ($scope, UserDataResource) {

    function activate() {
        UserDataResource.getUsersMostReviews().then(function (response) {
            $scope.usersMostReviews = response;


        });

        UserDataResource.getUsersMostPhotos().then(function (response) {
            $scope.usersMostPhotos = response;


        });


    }

    activate();

});