module.exports = {
  templateUrl: require('./listBook.html'),
  controller: BookListController
};

/** @ngInject */
function BookListController($scope, $state, BookService, $log) {
  $scope.getList = getList;
  $scope.remove = remove;
  $scope.toUpdate = toUpdate;
  $scope.toCreate = toCreate;
  $scope.next = next;
  $scope.back = back;
  var paginationValue = 0;

  function init() {
    getList(0);
  }
  init();

  function next() {
    var page = paginationValue++;
    getList(page);
  }

  function back() {
    var page = paginationValue--;
    getList(page);
  }

  function getList(page) {
    BookService.getPaginated(page)
      .then(function (response) {
        $scope.bookList = response;
      });
  }

  function remove(id) {
    BookService.remove(id)
      .then(function (response) {
        $log.info(response);
      });
  }

  function toUpdate(id) {
    if (id.length > 0) {
      $state.go('book.update', id);
    }
  }

  function toCreate() {
    $state.go('book.create');
  }
}
