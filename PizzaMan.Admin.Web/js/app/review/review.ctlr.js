angular.module('app').controller('ReviewController', function ($scope, ReviewResource) {

    function activate() {
        $scope.reviews = ReviewResource.query();
    }

    activate();
});