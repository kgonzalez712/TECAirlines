var URL = '192.168.100.20'
var SUCURSAL = "TECAirlines"

var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){
	
	
	//Funcion usada para crear una nueva universidad con los datos brindados
	$scope.crearUniversidad = function(){
		$http({
			method: 'POST',
			url:'http://' + URL + '/TECAirlinesAPI/Universities/NewUniversity',
			data: $scope.avion
		}).then(function successCallback(response){
			alert("User has created Successfully")
		}, function errorCallback(response){
			alert("Error while created User");
		});
		// $http.post('',$scope.user,{headers:{'Content-Type':'application/x-www-form-urlencoded'}}).then(function(response){});
	};

});