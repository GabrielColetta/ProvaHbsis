var angular = require('angular');
require('bootstrap');

var bookList = require('./app/book/listBook.controller');
var bookCreate = require('./app/book/createBook.controller');
var bookUpdate = require('./app/book/updateBook.controller');
var bookService = require('./app/book/book.service');
require('angular-ui-router');
var routesConfig = require('./routes');
require('./index.css');

angular
    .module('app', ['ui.router'])
    .config(routesConfig)
    .service('BookService', bookService)
    .component('bookList', bookList)
    .component('bookCreate', bookCreate)
    .component('bookUpdate', bookUpdate);
