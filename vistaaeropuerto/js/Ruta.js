var URL = '192.168.100.20'
var myApp = angular.module('myApp', []);

myApp.controller("appController",function($scope,$http){

	//Funcion usada para traer los ID de todos los vuelos y mostrarlos
	$http.get('http://' + URL + '/TECAirlinesAPI/FlightID').
    then(function(response) {
		$scope.vuelos = response.data;
	});
	
	//Funcion usada para traer todos los aeropuertos y mostrarlos
	$http.get('http://' + URL + '/TECAirlinesAPI/Airports').
    then(function(response) {
		$scope.aeropuertos = response.data;
	});
	
	//Funcion usada para crear una nueva ruta
    $scope.crearRuta = function(ruta){
		$scope.ruta = ruta;
        $scope.ruta.FLIGHT_ID = $scope.ruta.FLIGHT_ID;
		$scope.ruta.ORIGIN = $scope.ruta.ORIGIN.IATA_CODE;
		$scope.ruta.DESTINATION = $scope.ruta.DESTINATION.IATA_CODE;
		$http({
			method: 'POST',
            url:'http://' + URL + '/TECAirlinesAPI/Routes/AddRoute',
			data: $scope.ruta
		}).then(function successCallback(response){
			alert("Route has created Successfully")
		}, function errorCallback(response){
			alert("Error while created route");
		});
	};

});