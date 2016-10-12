<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AjaxWebApplication.WebForm1" %>

<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">

    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js">
    </script>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootswatch/3.2.0/sandstone/bootstrap.min.css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css">
    <style>
        body { padding-top:10px;font-size: 13px;}
        .table{ width: 70%; height: }
    </style>
<body ng-app="myApp" >

  
       
        <div  ng-controller="myCtrl" data-ng-init="retData.getResult()">
             <%--<button ng-click="retData.getResult()">Send AJAX Request</button> <br/>--%>
            Show Data:<input type="checkbox" checked="" ng-model="IsVisible"/>
            <div class="alert alert-info">
    <p>Sort Type: {{ sortType }}</p>
    <p>Sort Reverse: {{ sortReverse }}</p>
    <p>Search Query: {{ searchItem }}</p>
  </div>
   
             <form>
    <div class="form-group">
      <div class="input-group">
        <div class="input-group-addon"><i class="fa fa-search"></i></div>

        <input type="text" class="form-control" placeholder="Search The Item" ng-model="searchItem">

      </div>      
    </div>
            <div ng-show="IsVisible">
            <%--<table border="1">
                <tr>
                    <th>Item</th>
                    <th>Quanity</th>
                    <th>Date</th>
                </tr>
              <tr ng-repeat="x in myData ">
                <td>{{ x.item }}</td>
                <td>{{x.qty}}</td>
                  <td>{{x.date | jsonDate}}</td>
              </tr>
            </table>--%>
             <table class="table table-bordered table-striped table-hover" style="font-size: 15px;">
    
    <thead>
      <tr>
        <td>
			<a href="#" ng-click="sortType='item'; sortReverse=!sortReverse">
            Item
				<span ng-show="sortType == 'item'&& sortReverse==false" class="fa fa-caret-down"></span>
			  <span ng-show="sortType == 'item' && sortReverse==true" class="fa fa-caret-up"></span>
				</a>
        </td>
        <td>
          <a href="#" ng-click="sortType = 'qty'; sortReverse=!sortReverse">
         
          Quantity 
			   <span ng-show="sortType == 'qty' && sortReverse==false" class="fa fa-caret-down"></span>
			  <span ng-show="sortType == 'qty'&& sortReverse==true" class="fa fa-caret-up"></span>
          </a>
        </td>
        <td>
         <a href="#" ng-click="sortType = 'date'; sortReverse=!sortReverse">
          
          Date 
			 <span ng-show="sortType == 'date' && sortReverse==false" class="fa fa-caret-down"></span>
			  <span ng-show="sortType == 'date' && sortReverse==true" class="fa fa-caret-up"></span>
          </a>
        </td>
          <td>
         <a href="#" ng-click="sortType = 'phone'; sortReverse=!sortReverse">
          
          phone 
			 <span ng-show="sortType == 'phone' && sortReverse==false" class="fa fa-caret-down"></span>
			  <span ng-show="sortType == 'phone' && sortReverse==true" class="fa fa-caret-up"></span>
          </a>
              </td>
          <td> <a href="#">Remove</a></td>
      </tr>
    </thead>
    
    <tbody>
      <tr ng-repeat="(dataIndex,roll) in myData | orderBy:sortType:sortReverse | filter:searchItem | filter:jsonDate">
        <td>{{ roll.item }}</td>
        <td>{{ roll.qty }}</td>
        <td>{{ roll.date | jsonDate }}</td>
          <td>{{ roll.phone | tel}}</td>
          <td><button class="btn btn-danger remove show_tip" ng-click="retData.deleteResult(roll.Id)">Remove</button></td>
      </tr>
        <tr>
            <td><input type="text" ng-model="item" id="item1"/></td>
            <td><input type="text" ng-model="qty" id="qty1"/></td>
            <td><input type="date" ng-model="date" id="date"/></td>
            <td><input type="text" ng-model="phone" id="phone"/></td>
            <td><input class="btn btn-primary" type="submit" ng-click="retData.saveResult()" value="Insert"/></td>
        </tr>
    </tbody>
    
  </table>
  
            <br />  
<div >Result from server: {{myData}}  </div>
  </div>
             </form>


        </div>
     
        <script>
           /* $(document).ready(function() {
               // retDate.getResult(item,$event);
            });*/
            (function() {
                
           
            angular.module("myApp", [])
                .controller("myCtrl", function ($scope, $http) {
                    $scope.retData = {};
                    $scope.searchItem = '';
                    $scope.sortType = '';
                    $scope.sortReverse = false;
                    $scope.IsVisible = true;
                    $scope.retData.getResult = function () {
                        $http.post('WebForm1.aspx/GetData', { data: {} })
                            .success(function (data, status, headers, config) {
                                
                                $scope.myData = data.d.MyList;

                            })
                            .error(function (data, status, headers, config) {
                                $scope.status = status;
                            });
                    };
                    $scope.retData.saveResult = function () {
                        $scope.data1 = { "item": $scope.item, "qty": $scope.qty,"date":$scope.date,"phone":$scope.phone };
                        $http.post('WebForm1.aspx/SaveData',$scope.data1).success(function (data, status, headers, config) {
                                console.log(data);

                                $scope.retData.getResult();
                                $scope.item = '';
                                $scope.qty = '';
                                $scope.date = '';
                                $scope.phone = '';
                                // $scope.myData = data.d.MyList;*/

                            })
                            .error(function (data, status, headers, config) {
                                $scope.status = status;
                            });
                    };
                    $scope.retData.deleteResult = function (x) {
                        $scope.data1 = { "id": x};
                        $http.post('WebForm1.aspx/DeleteData', $scope.data1).success(function (data, status, headers, config) {
                            console.log(data);

                            $scope.retData.getResult();
                           
                            // $scope.myData = data.d.MyList;*/

                        })
                            .error(function (data, status, headers, config) {
                                $scope.status = status;
                            });
                        console.log(x);
                    };
                }).config(function ($httpProvider) {
                    $httpProvider.defaults.headers.post = {};
                    $httpProvider.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";
                }).filter('jsonDate', ['$filter', function ($filter) {
                    return function (input, format) {
                        return (input)
                            ? $filter('date')(parseInt(input.substr(6)), format)
                            : '';
                    };
                }]).filter('tel', function () {
                    return function (tel) {
                        if (!tel) { return ''; }

                        var value = tel.toString().trim().replace(/^\+/, '');

                        if (value.match(/[^0-9]/)) {
                            return tel;
                        }

                        var country, city, number;

                        switch (value.length) {
                            case 10: // +1PPP####### -> C (PPP) ###-####
                                country = 1;
                                city = value.slice(0, 3);
                                number = value.slice(3);
                                break;

                            case 11: // +CPPP####### -> CCC (PP) ###-####
                                country = value[0];
                                city = value.slice(1, 4);
                                number = value.slice(4);
                                break;

                            case 12: // +CCCPP####### -> CCC (PP) ###-####
                                country = value.slice(0, 3);
                                city = value.slice(3, 5);
                                number = value.slice(5);
                                break;

                            default:
                                return tel;
                        }

                        if (country == 1) {
                            country = "";
                        }

                        number = number.slice(0, 3) + '-' + number.slice(3);

                        return (country + " (" + city + ") " + number).trim();
                    };
                });;
            })();
        </script>  
  
</body>
</html>
