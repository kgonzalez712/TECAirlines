var URL = '192.168.100.20'
var SUCURSAL = "TECAirlines"

var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){
	
	//Funcion para crear un nuevo piloto con los datos ingresados
	$scope.createPilot = function(){
		$http({
			method: 'POST',
			url:'http://' + URL + '/TECAirlinesAPI/Pilots/NewPilot',
			data: $scope.pilot
		}).then(function successCallback(response){
			alert("User has created Successfully")
		}, function errorCallback(response){
			alert("Error while created User");
		});
	};

});