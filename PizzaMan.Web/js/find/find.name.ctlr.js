angular.module('app').controller('FindNameController', function ($scope, FindResource, $stateParams, PhotoResource) {

    var name = $stateParams.name;

    function activate() {
        FindResource.getPizzeriaByName(name).then(function (response) {
            $scope.pizzerias = response;
           
        });

        FindResource.getPizzeriaByName(name).then(function (response) {
            $scope.pizzerias = response;

        });

    }

    activate();

   

});