angular.module('app').controller('AppController', function ($scope, AuthenticationService) {
    $scope.logout = function () {
        AuthenticationService.logout();
        location.replace('/#/home')
    }

});