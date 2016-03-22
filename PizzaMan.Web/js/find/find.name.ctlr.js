angular.module('app').controller('FindNameController', function ($scope, FindResource, $stateParams) {

    var name = $stateParams.name;

    function activate() {
        FindResource.getPizzeriaByName(name).then(function (response) {
            $scope.pizzerias = response;
        });

    }

    activate();

    $scope.mySlides = ['http://localhost:49923/../../img/o.jpg', 'http://localhost:49923/../../img/photo-1453831210728-695502f9f795.jpg', 'http://localhost:49923/../../img/pizza-744405_960_720.jpg'];

});