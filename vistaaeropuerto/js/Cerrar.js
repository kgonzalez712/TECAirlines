var URL = '172.18.120.69'

var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){

	//Funcion para traer todos los vuelos de la BD y almacenarlos en "vuelos" para usar su informacion
	$http.get('http://' + URL + '/TECAirlinesAPI/Flights').then(function(response){ //cambiar link
		$scope.vuelos = response.data;
	});

	//Funcion para cambiar el estado del vuelo a inactivo
	$scope.updateVuelo = function(vuelo){
		$scope.vuelo = vuelo;
		alert($scope.vuelo.FLIGHT_ID);
		$http({
			method: 'PUT',
			url: 'http://' + URL + '/TECAirlinesAPI/Flights/ChangeStatus/' + $scope.vuelo.FLIGHT_ID,
			data: $scope.vuelo
		}).then(function successCallback(response){ 
			alert("Flight has updated Successfully")
		}, function errorCallback(response){
			alert("Error while updating flight");
		});
	};



});