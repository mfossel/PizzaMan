angular.module('app').controller('FindZipController', function ($scope, FindResource, $stateParams) {

    var zip = $stateParams.zip;

    function activate() {
        FindResource.getPizzeriaByZip(zip).then(function (response) {
            $scope.pizzerias = response;
            $scope.zip = zip;
        });

    }

    activate();

    });