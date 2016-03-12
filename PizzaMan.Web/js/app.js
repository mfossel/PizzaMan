angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule']);

angular.module('app').value('apiUrl', 'http://localhost:63608/api/');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');
    $urlRouterProvider.otherwise('home');
    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
          .state('home.dashboard', { url: '/dashboard', parent:'home', templateUrl: '/templates/dashboard/dashboard.html', controller: 'DashboardController' })
          .state('home.review', { url: '/review', parent: 'home', templateUrl: '/templates/review/review.html', controller: 'ReviewController' })
          .state('home.login', { url: '/login', parent: 'home', templateUrl: '/templates/account/login.html', controller: 'LoginController' })
          .state('home.register', { url: '/register', parent: 'home', templateUrl: '/templates/account/register.html', controller: 'RegisterController' })
    ;
});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});