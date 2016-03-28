angular.module('app').controller('UserDataController', function ($scope, UserDataResource) {

    function activate() {
        UserDataResource.getUsersMostReviews().then(function (response) {
            $scope.usersMostReviews = response;


        });

        UserDataResource.getUsersMostPhotos().then(function (response) {
            $scope.usersMostPhotos = response;


        });

        UserDataResource.getUsersAvgNumReviews().then(function (response) {
            $scope.usersAvgNumReviews = response;


        });

        UserDataResource.getUsersAvgNumPhotos().then(function (response) {
            $scope.usersAvgNumPhotos = response;


        });

        UserDataResource.getUsers().then(function (response) {
            $scope.users = response;


        });

    }

    activate();

});