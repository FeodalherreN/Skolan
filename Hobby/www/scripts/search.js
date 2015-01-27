angular.module('testModule', [])
.controller('searchController', function($scope) {
  $scope.songs = ['Stairway to heaven', 'About a girl', 'Smells like teen spirit'];
});