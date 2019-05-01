var URL = '172.18.120.69'
var SUCURSAL = "TECAirlines"
var myApp = angular.module('myApp', []);

myApp.controller("appController", function ($scope, $http) {

	$http.get('http://' + URL + '/TECAirlinesAPI/Flights/Promotions').then(function(response){ //cambiar link
		$scope.promociones = response.data;
	});

});