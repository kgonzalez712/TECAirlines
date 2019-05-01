var URL = '192.168.100.20'

var myApp = angular.module('myApp', []);
myApp.controller("appController", function ($scope, $http) {

	//Carga todos los pilotos en el objeto pilots
	$http.get('http://' + URL + '/TECAirlinesAPI/Pilots').
		then(function (response) {
			$scope.pilots = response.data;
		});

	//funcion para crear un nuevo avion en la DB
	$scope.createPlane = function (avion) {
		$scope.avion = avion;
		$scope.avion.PILOT_ID = $scope.avion.PILOT_ID.PILOT_ID;
		$http({
			method: 'POST',
			url: 'http://' + URL + '/TECAirlinesAPI/Airplanes/NewAirPlane',
			data: $scope.avion
		}).then(function successCallback(response) {
			alert("User has created Successfully")
		}, function errorCallback(response) {
			alert("Error while created User");
		});
		// $http.post('',$scope.user,{headers:{'Content-Type':'application/x-www-form-urlencoded'}}).then(function(response){});
	};

});