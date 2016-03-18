angular.module('app').controller('HomeController', function ($scope, AuthenticationService, HomeResource) {
    function activate() {
        HomeResource.getCurrentUser().then(function (response) {
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