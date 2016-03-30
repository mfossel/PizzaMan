angular.module('app').service('fileUpload', ['$http', 'apiUrl', function ($http, apiUrl) {
    this.uploadPizzeriaPhoto = function (file, pizzeriaId ) {
        var fd = new FormData();
        fd.append('file', file);
        $http.post(apiUrl + 'upload/pizzeriaPhoto/' + pizzeriaId, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function () {
            
            location.reload();
            
        })
        .error(function () {
            toastr.error('Error uploading')
        });
    }
}]);