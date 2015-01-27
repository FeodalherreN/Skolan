var App = angular.module('App', ['ngRoute']);

App.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/songs', {templateUrl: 'songs.html', controller: 'searchController'});
    $routeProvider.when('/persons', {templateUrl: 'persons.html', controller: 'personController' });
    $routeProvider.otherwise({ redirectTo: '/songs' });
}]);

App.controller('personController', function($scope, $http){
	$http.get('../JSON/testdata.json')
	.then(function(res){
		$scope.persons = res.data;
	});
});

App.controller('searchController', function($scope) {
  $scope.songs = ['Stairway to heaven', 'About a girl', 'Smells like teen spirit', 'In da club', 'Levels', 'Lethal Industry', 'Tribute'];
});