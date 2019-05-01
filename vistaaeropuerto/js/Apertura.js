var URL = '172.18.120.69'

var myApp = angular.module('myApp', []);
myApp.controller("appController", function ($scope, $http) {

	//Para mostrar una parte de la pagina con el ng Show
	$scope.confirmarPasajero = false;
	$scope.seleccionarVuelo = true;

	//Se cargan todos los vuelos en el objeto vuelo para cargar la tabla
	$http.get('http://' + URL + '/TECAirlinesAPI/Flights').then(function (response) { //cambiar link
		$scope.vuelos = response.data;
	});	

	//Funcion para hacer el checkin de la reservacion indicada
	$scope.hacerCheckIn = function (vuelo) {
		$scope.vuelo = vuelo;
		$http({
			method: 'PUT',
			url: 'http://' + URL + '/TECAirlinesAPI/Reservations/CheckIn/' + $scope.vuelo.Reservacion_ID,
			data: $scope.vuelo
		}).then(function successCallback(response) {
			alert("CheckIn has updated Successfully")
		}, function errorCallback(response) {
			alert("Error while CheckIn");
		});
	};

	//Funcion para traer la reservacion
	$scope.traerReservaciones = function (vuelo) {
		$scope.vuelo = vuelo;
		$http.get('http://' + URL + '/TECAirlinesAPI/Reservations/' + $scope.vuelo.Reservacion_ID).then(function (response) { //cambiar link
			$scope.reservacion = response.data;
		});
	};

	//Funcion para agregar las millas al cliente
	$scope.agregarMillas = function(reservacion, vuelo){
		$scope.vuelo = vuelo;
		$scope.reservacion = reservacion;
		$http({
			method: 'PUT',
			url: 'http://' + URL + '/TECAirlinesAPI/Clients/Miles/' + $scope.reservacion[0].CLIENT_ID + '/' + ($scope.vuelo.FLIGHT_MILES/10) ,
			data: $scope.vuelo
		}).then(function successCallback(response) {
			alert("Miles has added Successfully")
			location.reload();
		}, function errorCallback(response) {
			alert("Error while adding");
		});
	}

	//funciones auxiliares para mostrar u ocultar las vistas
	$scope.apertura = function (vuelo) {
		$scope.vuelo = vuelo;
		$scope.seleccionarVuelo = false;
		$scope.confirmarPasajero = true;
	};
	$scope.seleccionar = function () {
		$scope.confirmarPasajero = false;
		$scope.seleccionarVuelo = true;
	};

});