angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule',]);

angular.module('app').value('apiUrl', 'http://localhost:49834/api/');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');
    $urlRouterProvider.otherwise('app');
    $stateProvider
       .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
       .state('app', { url: '/app', templateUrl: '/templates/app/app.html', controller: 'AppController' })
       .state('app.dashboard', { url: '/dashboard', parent: 'app', templateUrl: '/templates/dashboard/dashboard.html', controller: 'DashboardController' })

       .state('app.photo', { url: '/app/photo', parent: 'app', templateUrl: '/templates/photo/photo.html', controller: 'PhotoController' })
       .state('app.pizzeria', { url: '/app/pizzeria', parent: 'app', templateUrl: '/templates/pizzeria/pizzeria.html', controller: 'PizzeriaController' })
       .state('app.review', { url: '/app/review', parent: 'app', templateUrl: '/templates/review/review.html', controller: 'ReviewController' })
       .state('app.user', { url: '/app/user', parent: 'app', templateUrl: '/templates/user/user.html', controller: 'UserController' })
        ;
});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});