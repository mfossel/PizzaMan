angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule', 'angular-input-stars']);

angular.module('app').value('apiUrl', 'http://localhost:49834/api/');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');
    $urlRouterProvider.otherwise('home/dashboard');
    $stateProvider
       .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
          .state('home.dashboard', { url: '/dashboard', parent:'home', templateUrl: '/templates/dashboard/dashboard.html', controller: 'DashboardController' })
          
          .state('home.login', { url: '/login', parent: 'home', templateUrl: '/templates/account/login.html', controller: 'AccountController' })
          .state('home.register', { url: '/register', parent: 'home', templateUrl: '/templates/account/register.html', controller: 'AccountController' })
          .state('home.submit', { url: '/submit', parent: 'home', templateUrl: '/templates/submit/submit.html', controller: 'SubmitController' })
          .state('home.find', { url: '/find', parent: 'home', templateUrl: '/templates/find/find.html', controller: 'FindController' })
                .state('home.find.zip', { url: '/find/zip=:zip', parent: 'home', templateUrl: '/templates/find/find.results.html', controller: 'FindZipController' })
                .state('home.find.city', { url: '/find/city=:city', parent: 'home', templateUrl: '/templates/find/find.results.html', controller: 'FindCityController' })
                .state('home.find.name', { url: '/find/name=:name', parent: 'home', templateUrl: '/templates/find/find.results.html', controller: 'FindNameController' })
          .state('home.pizzeria', { url: '/pizzeria', parent: 'home', templateUrl: '/templates/pizzeria/pizzeria.html', controller: 'PizzeriaController' })
          .state('home.review', { url: '/review', parent: 'home', templateUrl: '/templates/review/review.html', controller: 'HomeController' })
                 .state('home.review.pizzeria', { url: '/review/pizzeria=:name', parent: 'home', templateUrl: '/templates/review/review.pizzeria.html', controller: 'ReviewController' })
                 .state('home.review.display', { url: '/review/display=:id', parent: 'home', templateUrl: '/templates/review/review.display.html', controller: 'ReviewController' })
    ;
});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});