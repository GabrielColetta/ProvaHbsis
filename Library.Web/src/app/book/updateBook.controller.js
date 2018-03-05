module.exports = {
  templateUrl: require('./book.html'),
  controller: BookUpdateController
};

/** @ngInject */
function BookUpdateController($scope, $state, $log, $routeParams, BookService) {
  $scope.sendForm = sendForm;
  $scope.returnPage = returnPage;
  $scope.page = {title: 'Editar livro', persistName: 'Editar'};

  function init() {
    BookService.getById($routeParams.id)
      .then(function (response) {
        $scope.book = response;
      });
  }
  init();

  function sendForm() {
    if ($scope.bookForm.$valid) {
      var params = {
        id: $scope.book.id,
        title: $scope.book.title,
        subtitle: $scope.book.subtitle,
        subject: $scope.book.subject,
        publisher: $scope.book.publisher,
        author: $scope.book.author,
        publishDate: new Date($scope.book.publishDate)
      };
      BookService.update(params)
        .then(function (response) {
          $log.info(response);
          $state.go('book.list');
        });
    }
  }

  function returnPage() {
    $state.go('book.list');
  }
}
