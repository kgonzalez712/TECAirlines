var URL = '172.18.178.9'

var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){

	//Funcion utilizada para traer todos los datos de los aviones
	$http.get('http://' + URL + '/TECAirlinesAPI/Airplanes').then(function(response){ //cambiar link
		$scope.aviones = response.data;
	});



});