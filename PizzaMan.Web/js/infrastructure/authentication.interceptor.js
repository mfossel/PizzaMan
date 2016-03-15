angular.module('app').factory('AuthenticationInterceptor', function ($q, localStorageService) {
    function interceptRequest(request) {
        var token = localStorageService.get('token');

        if (token) {
            request.headers.Authorization = 'Bearer ' + token.token;
        }

        return request;
    }

    function interceptResponse(response) {
        if (response.status === 401) {
            location.replace('/#/home/login'); //we will look here if we will get a problem using the login :))))))
        }

        return $q.reject(response);
    }

    return {
        request: interceptRequest,
        responseError: interceptResponse
    };
});