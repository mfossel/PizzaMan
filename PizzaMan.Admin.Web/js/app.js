angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule',]);

angular.module('app').value('apiUrl', 'http://localhost:49834/api/');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');
    $urlRouterProvider.otherwise('app/dashboard');
    $stateProvider
       .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
       .state('app', { url: '/app', templateUrl: '/templates/app/app.html', controller: 'AppController' })
       .state('app.dashboard', { url: '/dashboard', parent: 'app', templateUrl: '/templates/app/dashboard/dashboard.html', controller: 'DashboardController' })
       .state('app.photo', { url: '/photo', parent: 'app', templateUrl: '/templates/app/photo/photo.html', controller: 'PhotoController' })
       .state('app.pizzeria', { url: '/pizzeria', parent: 'app', templateUrl: '/templates/app/pizzeria/pizzeria.html', controller: 'PizzeriaController' })
             .state('app.pizzeriadata', { url: '/data/pizzeria', parent: 'app', templateUrl: '/templates/app/pizzeria/pizzeria.data.html', controller: 'PizzeriaDataController' })
             .state('app.pizzeriaedit', { url: '/pizzeria/edit/id=:id', parent: 'app', templateUrl: '/templates/app/pizzeria/pizzeria.edit.html', controller: 'PizzeriaEditController' })
       .state('app.review', { url: '/review', parent: 'app', templateUrl: '/templates/app/review/review.html', controller: 'ReviewController' })
       .state('app.userdata', { url: '/data/user', parent: 'app', templateUrl: '/templates/app/user/user.data.html', controller: 'UserDataController' })

        ;
});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});