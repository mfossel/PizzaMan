angular.module('app').controller('PhotoController', function ($scope, PhotoResource, PizzeriaResource, $stateParams, fileUpload) {

    $scope.pizzeria = PizzeriaResource.get({ pizzeriaId: $stateParams.id });

    $scope.uploadPhoto = function () {
        var file = $scope.pizzeriaPhoto;
        var pizzeriaId = $scope.pizzeria.PizzeriaId;
        fileUpload.uploadPizzeriaPhoto(file, pizzeriaId);
        toastr.success('Photo successfully uploaded!');
    };

});