<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="AjaxWebApplication.Sample" %>

<!DOCTYPE html>

<html>  
    <head>  
        <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.5/angular.min.js"></script>  
        <script>
            angular.module("myapp", [])
            .controller("MyController", function ($scope, $http) {
                $scope.retData = {};
                $scope.retData.getResult = function (item, event) {
                    $http.post('Sample.aspx/GetEmployees', { data: {} })
                    .success(function (data, status, headers, config) {
                        $scope.retData.result = data.d;
                    })
                    .error(function (data, status, headers, config) {
                        $scope.status = status;
                    });
                }
            }).config(function ($httpProvider) {
                $httpProvider.defaults.headers.post = {};
                $httpProvider.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";
            });
</script>  
    </head>  
    <body ng-app="myapp">  
        <div ng-controller="MyController">  
            <button ng-click="retData.getResult(item, $event)">Send AJAX Request</button>  
            <br />  
Result from server: {{retData.result | json}}  
  
        </div>  
    </body>  
</html>
