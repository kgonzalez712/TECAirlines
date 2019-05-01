var URL = '172.18.178.9'
var SUCURSAL = "TECAirlines"
var myApp = angular.module('myApp', []);

myApp.controller("appController", function ($scope, $http) {

	//Funcion usada oara traer todas las promociones para mostras sus datos
	$http.get('http://' + URL + '/TECAirlinesAPI/Flights/Promotions').then(function(response){ //cambiar link
		$scope.promociones = response.data;
	});

});