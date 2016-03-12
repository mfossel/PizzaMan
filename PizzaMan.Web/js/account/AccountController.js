angular.module('app').controller('AccountController', function ($scope, AuthenticationService) {
    $scope.loginData = {};

    $scope.login = function () {
        AuthenticationService.login($scope.loginData).then(
            function (response) {
                location.replace('/#/home/login');
            },
            function (err) {
                alert(err.error_description);
            }
        );
    };

    $scope.logout = function () {
        AuthenticationService.logout();
    }

    $scope.registration = {};

    $scope.register = function () {
        AuthenticationService.register($scope.registration).then(
            function (response) {
                alert("Registration complete.");
                $scope.registration = {};
            },
            function (error) {
                alert("Failed to register");
            }
        )
    };
});