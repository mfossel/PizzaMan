angular.module('app').controller('PhotoController', function ($scope, PhotoResource) {

    function activate() {
        $scope.photos = PhotoResource.query();
    }

    activate();
});