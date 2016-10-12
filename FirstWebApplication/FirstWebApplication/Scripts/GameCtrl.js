angular.module('FirstWebApplication.GameController', [])
    .controller('GameCtrl',['$scope','$http',
        function($scope,$http) {
            $http.get('Game/IndexVM')
                .success(function(data) {
                    $scope.model = data;
                });
        }]);