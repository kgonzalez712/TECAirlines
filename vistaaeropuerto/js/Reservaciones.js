var URL = '172.18.178.9'

var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){

	//Funcion usada para traer todas las reservaciones y usar sus datos
	$http.get('http://' + URL + '/TECAirlinesAPI/Reservations').then(function(response){ //cambiar link
		$scope.reservaciones = response.data;
	});


});