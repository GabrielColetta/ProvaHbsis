module.exports = BookService;

function BookService($http) {
  var urlApi = 'http://localhost:2876/api/book/';
  return {
    GetPaginated: getPaginated,
    getById: getById,
    create: create,
    update: update,
    remove: remove
  };
  function returnSucess(response) {
    return response;
  }

  function returnFailure(error) {
    return error;
  }

  function getPaginated(page) {
    return $http.get(urlApi + 'page/' + page)
      .then(returnSucess)
      .catch(returnFailure);
  }

  function getById(id) {
    return $http.get(urlApi + id)
      .then(returnSucess)
      .catch(returnFailure);
  }

  function create(params) {
    return $http.post(urlApi, params)
      .then(returnSucess)
      .catch(returnFailure);
  }

  function update(params) {
    return $http.put(urlApi, params)
      .then(returnSucess)
      .catch(returnFailure);
  }

  function remove(id) {
    return $http.delete(urlApi + id)
      .then(returnSucess)
      .catch(returnFailure);
  }
}
