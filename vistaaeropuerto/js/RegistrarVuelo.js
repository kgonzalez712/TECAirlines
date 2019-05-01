var URL = '172.18.120.69'
var myApp = angular.module('myApp', []);

myApp.controller("appController",function($scope,$http){

	//Funcion para traer todos aviones y usar sus datos
	$http.get('http://' + URL + '/TECAirlinesAPI/AirPlanes').
    then(function(response) {
		$scope.aviones = response.data;
	});
	
	//Funcion usada para traer todos los aeropuertos y usar sus datos
	$http.get('http://' + URL + '/TECAirlinesAPI/Airports').
    then(function(response) {
		$scope.aeropuertos = response.data;
	});
	
	//Funcion usada pra crear un nuevo vuelo
    $scope.crearVuelo = function(vuelo){
		$scope.vuelo = vuelo;
        $scope.vuelo.PLANE_ID = $scope.vuelo.PLANE_ID.AIRPLANE_ID;
		$scope.vuelo.ORIGIN_AIRPORT = $scope.vuelo.ORIGIN_AIRPORT.IATA_CODE;
		$scope.vuelo.DESTINATION_AIRPORT = $scope.vuelo.DESTINATION_AIRPORT.IATA_CODE;
		$http({
			method: 'POST',
            url:'http://' + URL + '/TECAirlinesAPI/Flights/AddFlight',
			data: $scope.vuelo
		}).then(function successCallback(response){
			alert("Flight has created Successfully")
		}, function errorCallback(response){
			alert("Error while created Flight");
		});
	};

});