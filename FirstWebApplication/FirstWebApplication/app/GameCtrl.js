angular.module('FirstWebApplication.GameController', [])
    .controller('GameCtrl',['$scope','$http',
        function ($scope, $http) {
            $scope.model = {};
            $scope.states = {
                showGameForm: false
            };
            $scope.new = {
                Game:{}
            };
            $http.get('IndexVM')
                .success(function(data) {
                    $scope.model = data;
                });
            $scope.showGameForm=function(show) {
                $scope.states.showGameForm = show;
            };
            $scope.addGame=function() {
                $http.post('/Game/Create',$scope.new.Game).success(function(data) {
                    $scope.model.push(data);
                    $scope.showGameForm(false);
                    $window.location.reload();
                    $scope.new.Game = {};
                });
            };
        }]).filter('jsonDate', ['$filter', function ($filter) {
            return function (input, format) {
                return (input)
                       ? $filter('date')(parseInt(input.substr(6)), format)
                       : '';
            };
        }]);
