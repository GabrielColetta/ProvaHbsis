module.exports = {
  templateUrl: require('./book.html'),
  controller: BookCreateController
};

/** @ngInject */
function BookCreateController($scope, $state, BookService, $log) {
  $scope.sendForm = sendForm;
  $scope.returnPage = returnPage;
  $scope.page = {title: 'Adicionar livro', persistName: 'Criar'};

  function sendForm() {
    if ($scope.bookForm.$valid) {
      var params = {
        title: $scope.book.title,
        subtitle: $scope.book.subtitle,
        subject: $scope.book.subject,
        publisher: $scope.book.publisher,
        author: $scope.book.author,
        publishDate: new Date($scope.book.publishDate)
      };
      BookService.create(params)
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
