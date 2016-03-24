angular.module('app').controller('ReviewController', function ($scope, ReviewResource) {

    function activate() {
        $scope.reviews = ReviewResource.query();
    }

    $scope.deleteReview = function (review) {
        review.$remove(function (data) {
            activate();
            toastr.success('Review Deleted');
        })
        
    };


    activate();
});