angular.module('app').controller('FindZipController', function ($scope, FindResource, $stateParams) {

    var zip = $stateParams.zip;

    function activate() {
        FindResourcegetPizzeriaByZip(zip).then(function (response) {
            $scope.pizzerias = response;
        });

    }

    activate();

    });