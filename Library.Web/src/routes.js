module.exports = routesConfig;

/** @ngInject */
function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {
  $locationProvider.html5Mode(true).hashPrefix('!');
  $urlRouterProvider.otherwise('/');

  $stateProvider
    .state('index', {
      url: '/',
      component: 'bookList'
    })
    .state('book.list', {
      url: '/book',
      component: 'bookList'
    })
    .state('book.create', {
      url: '/book/create',
      component: 'bookCreate'
    })
    .state('book.update', {
      url: '/book/:id',
      component: 'bookUpdate'
    });
}
