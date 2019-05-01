var URL = '172.18.178.9'

var myApp = angular.module('myApp', []);
myApp.controller("appController", function ($scope, $http) {

	//Manejo del ng-show para mostrar/ocultar las diferentes vistas
	$scope.chequearVuelo = false;
	$scope.seleccionarVuelo = true;

	//Se trae todos los vuelos y se almacena en "vuelos" para uso de su data
	$http.get('http://' + URL + '/TECAirlinesAPI/Flights').then(function (response) { //cambiar link
		$scope.vuelos = response.data;
	});

	//Se trae una reservacion en especifico para usar sus datos	
	$scope.traerReservaciones = function (vuelo) {
		$scope.vuelo = vuelo;

		$http.get('http://' + URL + '/TECAirlinesAPI/Reservations/' + $scope.vuelo.Reservacion_ID).then(function (response) { //cambiar link
			$scope.reservacion = response.data;
		});
	};

	//Funcion usada para enviar la informacion de la reservacion al usuario
	$scope.enviarEmail = function (reservacion, vuelo) {
		$scope.reservacion = reservacion;
		$scope.vuelo = vuelo;
		$http.get('http://' + URL + '/TECAirlinesAPI/Clients/' + $scope.reservacion[0].CLIENT_ID).then(function (response) { //cambiar link
			$scope.cliente = response.data;

			window.open('mailto:' + $scope.cliente[0].CLIENT_EMAIL + '?subject=Confirmacion de reservacion%20&body=' +
				'%0A ID del Vuelo: ' + vuelo.FLIGHT_ID +
				'%0A Pasajero: ' + $scope.cliente[0].CLIENT_FNAME + " " + $scope.cliente[0].CLIENT_LNAME +
				"%0A Vuela desde: " + vuelo.ORIGIN +
				"%0A Hasta:  " + vuelo.DESTINATION +
				'%0A Fecha y Hora de vuelo: ' + $scope.vuelo.DATE_HOUR +
				"%0A Valor del Ticket: " + reservacion[0].PRICE +
				"%0A %0A %0A %0A %0A"
			);
		});

	}

	//Funciones auxiliares para el manejo de las vistas
	$scope.chequear = function (vuelo) {
		$scope.vuelo = vuelo;
		$scope.seleccionarVuelo = false;
		$scope.chequearVuelo = true;
	};
	$scope.seleccionar = function () {
		$scope.chequearVuelo = false;
		$scope.seleccionarVuelo = true;
	};

});