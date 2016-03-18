angular.module('app').controller('HomeController', function ($scope, AuthenticationService, ProfileResource) {
    function activate() {
        ProfileResource.getCurrentUser().then(function (response) {
            $scope.user = response;
        });

        $scope.account = 'Account';

        if (!$scope.user)
        {
            $scope.account = 'Welcome ';
            
        }



    }

    $scope.logout = function () {
        AuthenticationService.logout();
        location.replace('/');
    }

    activate();
   
});