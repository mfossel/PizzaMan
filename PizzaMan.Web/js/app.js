angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule']);

angular.module('app').value('apiUrl', 'http://localhost:63608/api/');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');
    $urlRouterProvider.otherwise('home');
    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
          .state('home.dashboard', { url: '/dashboard', templateUrl: '/templates/dashboard/dashboard.html', controller: 'DashboardController' })
    
    ;
});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});