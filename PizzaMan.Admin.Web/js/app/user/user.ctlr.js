angular.module('app').controller('UserController', function ($scope, UserResource) {

    function activate() {
        $scope.users = UserResource.query();
    }

    activate();
});