//iniciador de la aplicación y el controlador de angularjs para el el cliente 
var app = angular.module('myApp',[]);
app.controller('myCtrl',function($scope,$http){
	$scope.ip = "172.18.178.9";
	$scope.buscarVuelo = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.vueloInfo;
	$scope.Login = false;
	$scope.promotions = false;
	$scope.home = true;
	$scope.account = false;
	$scope.accountInfo = false;
	$scope.client_id_reservation = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservationI = false;
	$http.get('http://' + $scope.ip + '/TECAirlinesAPI/Flights/Promotions').then(function(response){ //cambiar link
	$scope.promociones = response.data;
	});
	$http.get("http://" + $scope.ip + "/TECAirlinesAPI/Airports").then(function (response) {
        $scope.places = response.data;
    });
	$http.get('http://' + $scope.ip + '/TECAirlinesAPI/Universities').
    then(function(response) {
		$scope.options = response.data;
    });
	$scope.reservacion = false;
	$scope.info;
	$scope.reservatio = {"TICKET_COUNT":3,
						"LUGGAGE_COUNT":3,
						"SEATS":"",
						"CHECKIN":"N",
						"T_TYPE":"ECONOMICO",
						"PRICE":0,
						"CLIENT_ID":"304910462",
						"FLIGHT_ID":456
						}
	$scope.login = false;
	$scope.loginInfo;
	$scope.client;
	$scope.nologin = true;
	
	$scope.reservationActivationPage=function(){
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.home = false;
		$scope.Login = false;
		$scope.account = false;
		$scope.studentRegister = false;
		$scope.promotions = false;
		$scope.clientRegister = false;
		$scope.reservacion = false;
		$scope.accountInfo = false;
		$scope.client_id_reservation = true;
		$scope.pageLogin = false;
		$scope.buscarVuelo = false;
		$scope.clientRegister = false;
		$scope.reservationI = false;
	}
	//metodo para activar la pantalla de ver reservaciones
	$scope.reservationInfoPage = function(CLIENT_ID){
		$scope.CLIENT_ID = CLIENT_ID;
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.home = false;
		$scope.Login = false;
		$scope.account = false;
		$scope.studentRegister = false;
		$scope.promotions = false;
		$scope.clientRegister = false;
		$scope.client_id_reservation = false;
		$scope.reservacion = false;
		$scope.accountInfo = false;
		$scope.pageLogin = false;
		$scope.buscarVuelo = false;
		$scope.clientRegister = false;
		$http.get("http://" + $scope.ip + "/TECAirlinesAPI/Reservations/Client/"+$scope.CLIENT_ID).then(function (response) {
			$scope.myreservations = response.data;
		});
		$scope.reservationI = true;
	}
	//metodo que activa la panatalla de registro de clientes
	$scope.clientR = function(){
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.client_id_reservation = false;
		$scope.home = false;
		$scope.Login = false;
		$scope.account = false;
		$scope.studentRegister = false;
		$scope.promotions = false;
		$scope.clientRegister = false;
		$scope.reservacion = false;
		$scope.accountInfo = false;
		$scope.pageLogin = false;
		$scope.buscarVuelo = false;
		$scope.reservationI = false;
		$scope.clientRegister = true;
	};
	//metodo que activa la pantalla de registro de universitarios
	$scope.studentR = function(){
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.client_id_reservation = false;
		$scope.Login = false;
		$scope.account = false;
		$scope.home = false;
		$scope.studentRegister = false;
		$scope.clientRegister = false;
		$scope.reservationI = false;
		$scope.promotions = false;
		$scope.reservacion = false;
		$scope.accountInfo = false;
		$scope.pageLogin = false;
		$scope.buscarVuelo = false;
		$scope.studentRegister = true;
	};

	//metodo para activar pantalla de account
	$scope.accountPage = function(){
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.client_id_reservation = false;
		$scope.vueloInfo;
		$scope.home = false;
		$scope.Login = false;
		$scope.reservationI = false;
		$scope.promotions = false;
		$scope.account = true;
		$scope.studentRegister = false;
		$scope.clientRegister = false;
		$scope.reservacion = false;
	}


	//metodo para hacer get de cliente por id
	$scope.getAccount = function(CLIENT_ID){
		$scope.CLIENT_ID = CLIENT_ID;
		$http.get("http://" + $scope.ip + "/TECAirlinesAPI/Clients/"+$scope.CLIENT_ID).then(function (response) {
			$scope.client = response.data;
		});    
		$http.get("http://" + $scope.ip + "/TECAirlinesAPI/Clients/CardNo/"+$scope.CLIENT_ID).then(function (response) {
			$scope.card = response.data;
		});
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.vueloInfo;
		$scope.client_id_reservation = false;
		$scope.Login = false;
		$scope.account = false;
		$scope.promotions = false;
		$scope.home = false;
		$scope.reservationI = false;
		$scope.studentRegister = false;
		$scope.clientRegister = false;
		$scope.reservacion = false;
		$scope.accountInfo = true;
	}
	//método de login
    $scope.loginUser=function(log){
		$scope.loginInfo = log;
		$http.get('http://' + $scope.ip + '/TECAirlinesAPI/LogIn/' + $scope.loginInfo.CLIENT_EMAIL +"/"+ $scope.loginInfo.CLIENT_PASSWRD).
		then(function(response) {
			$scope.login = response.data;	
			$scope.nologin = !$scope.login;
		});
		$scope.verifyLoginN();
	};

//función para activar la pantalla para crear la reservacion
    $scope.createReservation = function(vuelo){
		$scope.info = vuelo;
		$scope.reservarVuelo = false;
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.Login = false;
		$scope.promotions = false;
		$scope.account = false;
		$scope.client_id_reservation = false;
		$scope.reservationI = false;
		$scope.studentRegister = false;
		$scope.clientRegister = false;
		$scope.reservacion = false;
		$scope.home = false;
		$scope.accountInfo = false;
		$scope.pageLogin = false;
		$scope.reservacion = true;

	};

//funcion para activar la página login
	$scope.loginPage = function(){
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.clientRegister = false;
		$scope.client_id_reservation = false;
		$scope.studentRegister = false;
		$scope.promotions = false;
		$scope.buscarVuelo = false;
		$scope.reservarVuelo = false;
		$scope.pageLogin = false;
		$scope.Login = false;
		$scope.account = false;
		$scope.reservationI = false;
		$scope.studentRegister = false;
		$scope.clientRegister = false;
		$scope.home = false;
		$scope.reservacion = false;
		$scope.accountInfo = false;
		$scope.pageLogin = true;
	}

//Funcion para verificar si está logueado o no
	$scope.verifyLogin = function(vuelo){
		if($scope.login){
			$scope.vueloInfo = vuelo;
			$scope.createReservation(vuelo);
		}else{
			$scope.loginPage();
		}
	};

//Funcion para verificar si está logueado o no
$scope.verifyLoginN = function(){
	if($scope.login){	
		$scope.pageLogin = false;
		$scope.buscarVuelo = false;
		$scope.promotions = false;
		$scope.reservationI = false;
		$scope.reservarVuelo = false;
		$scope.home = false;
		$scope.pageLogin = false;
		$scope.vueloInfo;
		$scope.Login = false;
		$scope.account = false;
		$scope.studentRegister = false;
		$scope.client_id_reservation = false;
		$scope.clientRegister = false;
		$scope.reservacion = false;
		$scope.accountInfo = false;
		$scope.buscarVuelo = true;
		/*$http.get("http://" + $scope.ip + "/TECAirlinesAPI/Reservations/Clients/"+$scope.CLIENT_ID).then(function (response) {
			$scope.myreservations = response.data;
		});*/
	}else{
		alert("Contraseña incorrecta")
		$scope.loginPage();
	}
};
	
//función para activar la pantalla para modificar un sucursal, entradas el sucursal a modificar
$scope.infoReservation = function(reservation){
	$scope.reservationInfo = reservation;
	$scope.search = $scope.reservation.reservationName;
	$scope.reservacion = false;
	$scope.buscarVuelo = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.reservationI = false;
	$scope.client_id_reservation = false;
	$scope.promotions = false;
	$scope.Login = false;
	$scope.home = false;
	$scope.account = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
	$scope.Pago = true;
	
};
//Activa la pagina para buscar vuelo
$scope.buscar = function (flight) {
	$scope.flight = flight;
	$scope.buscarVuelo = false;
	$scope.buscarVuelo = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.reservationI = false;
	$scope.client_id_reservation = false;
	$scope.promotions = false;
	$scope.Login = false;
	$scope.account = false;
	$scope.home = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
	$scope.reservarVuelo = true;
	$scope.flight.ORIGIN = $scope.flight.ORIGIN.IATA_CODE;
	$scope.flight.DESTINATION = $scope.flight.DESTINATION.IATA_CODE;
	$http.get("http://" + $scope.ip + '/TECAirlinesAPI/Flights/' + $scope.flight.ORIGIN + '/' + $scope.flight.DESTINATION).then(function (response) {
		$scope.vuelos = response.data;
		alert("Exitoso");
	});
};
//Abre la pagina de promociones
$scope.promotionR = function(vuelo){
	$scope.reservacion = false;
	$scope.reservationI = false;
	$scope.buscarVuelo = false;
	$scope.home = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.promotions = true;
	$scope.Login = false;
	$scope.account = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
	$scope.Pago = false;
	$scope.client_id_reservation = false;
}

$scope.reservar = function () {
	$scope.buscar = true;
	$scope.buscarVuelo = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.reservationI = false;
	$scope.promotions = false;
	$scope.Login = false;
	$scope.home = false;
	$scope.account = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
	$scope.client_id_reservation = false;
	$scope.reservar = false;
};

$scope.volverpagina = function(){
	$scope.listaVuelos = true;
	$scope.buscarVuelo = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.promotions = false;
	$scope.Login = false;
	$scope.reservationI = false;
	$scope.home = false;
	$scope.client_id_reservation = false;
	$scope.account = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
	$scope.reservacion = false;
	$scope.Pago = false;
}

//activa la pagina para buscar vuelo
$scope.buscador = function(){
	$scope.listaVuelos = false;
	$scope.buscarVuelo = true;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.client_id_reservation = false;
	$scope.promotions = false;
	$scope.Login = false;
	$scope.home = false;
	$scope.reservationI = false;
	$scope.account = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
}

//activa la pagina home
$scope.homeP = function(){
	$scope.listaVuelos = true;
	$scope.buscarVuelo = false;
	$scope.client_id_reservation = false;
	$scope.reservarVuelo = false;
	$scope.pageLogin = false;
	$scope.promotions = false;
	$scope.Login = false;
	$scope.reservationI = false;
	$scope.home = true;
	$scope.account = false;
	$scope.studentRegister = false;
	$scope.clientRegister = false;
	$scope.reservacion = false;
	$scope.accountInfo = false;
	$scope.reservacion = false;
	$scope.Pago = false;
}
//metodo para crear un usuario
$scope.createUser= function(user){
	$scope.user = user;
	$scope.user.CLIENT_UID = "";
	$scope.user.UNIVERSITY_ID = 0;
	$scope.user.CLIENT_MILES = 0;
	$http({
		method: 'POST',
		url:'http://' + $scope.ip + '/TECAirlinesAPI/Clients/AddClient',
		data: $scope.user
	}).then(function successCallback(response){
		alert("User has created Successfully")
	}, function errorCallback(response){
		alert("Error while created User");
	});
};
//metodo para crear un universitario
$scope.createUClient= function(client){
	$scope.client = client;
	$scope.client.CLIENT_MILES = 0;
	$scope.client.CLIENT_UID = $scope.client.CLIENT_UID.UNIVERSITY_ID;
	$http({
		method: 'POST',
		url:'http://' + $scope.ip + '/TECAirlinesAPI/Clients/AddClient',
		data: $scope.client
	}).then(function successCallback(response){
		alert("User has created Successfully")
	}, function errorCallback(response){
		alert("Error while created User");
	});
};
//método que llama a un post de una reservación
$scope.addReservation = function(reservation){
	$scope.reservation = reservation;
	$scope.reservation.SEATS = "";
	$scope.reservation.CHECKIN = "N";
	$scope.reservation.FLIGHT_ID = $scope.vueloInfo.FLIGHT_ID;
	$scope.reservation.PRICE = 0;
	$http({
		method: 'POST',
		url:'http://' + $scope.ip + '/TECAirlinesAPI/Reservations/NewReservation',
		data: $scope.reservation
	}).then(function successCallback(response){
		alert("Reservation has created Successfully")
	}, function errorCallback(response){
        alert("Error while created Reservation");
	});
};

//metodo de logout
	$scope.logout = function(){
		$scope.login = false;
		$scope.nologin = true;
		$scope.loginPage();
	}

});
