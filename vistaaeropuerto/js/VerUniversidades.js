var URL = '172.18.178.9'

var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){

	//Funcion utilizada para traer todos los datos de las universidades
	$http.get('http://' + URL + '/TECAirlinesAPI/Universities').then(function(response){ //cambiar link
		$scope.universidades = response.data;
	});



});