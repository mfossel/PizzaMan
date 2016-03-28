angular.module('app').controller('PizzeriaDataController', function ($scope, PizzeriaDataResource) {

    function activate() {
        PizzeriaDataResource.getPizzeriaMostReviews().then(function (response) {
            $scope.pizzeriaMostReviews = response;


        });

        PizzeriaDataResource.getPizzeriaHighestRated().then(function (response) {
            $scope.pizzeriaHighestRated = response;


        });

        PizzeriaDataResource.getPizzeriaHighestRatedDelivery().then(function (response) {
            $scope.pizzeriaHighestRatedDelivery = response;


        });


        PizzeriaDataResource.getPizzeriaHighestRatedSitdown().then(function (response) {
            $scope.pizzeriaHighestRatedSitdown = response;


        });

        PizzeriaDataResource.getPizzeriaHighestRatedGlutenFree().then(function (response) {
            $scope.pizzeriaHighestRatedGlutenFree = response;


        });


        PizzeriaDataResource.getPizzeriaOldest().then(function (response) {
            $scope.pizzeriaOldest = response;


        });


        PizzeriaDataResource.getAvgNumReviews().then(function (response) {
            $scope.avgNumReviews = response;


        });


        PizzeriaDataResource.getAvgRating().then(function (response) {
            $scope.avgRating = response;


        });

        PizzeriaDataResource.getPercentDelivery().then(function (response) {
            $scope.percentDelivery = response;


        });

        PizzeriaDataResource.getPercentAlcohol().then(function (response) {
            $scope.percentAlcohol = response;


        });

        PizzeriaDataResource.getPercentVegan().then(function (response) {
            $scope.percentVegan = response;


        });

        PizzeriaDataResource.getPercentGlutenFree().then(function (response) {
            $scope.percentGlutenFree = response;


        });

    }

    activate();

});