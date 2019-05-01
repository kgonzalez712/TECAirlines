var URL = '172.18.120.69'


var myApp = angular.module('myApp', []);
myApp.controller("appController",function($scope,$http){

	//Metodo para crear un nuevo usuario
	$scope.createUser= function(user){
		$scope.user = user;
		$scope.user.CLIENT_UID = "";
		$scope.user.UNIVERSITY_ID = 0;
		$scope.user.CLIENT_MILES = 0;
		$http({
			method: 'POST',
			url:'http://' + URL + '/TECAirlinesAPI/Clients/AddClient',
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
		alert($scope.client.CLIENT_UID.UNIVERSITY_ID);
		$http({
			method: 'POST',
			url:'http://' + URL + '/TECAirlinesAPI/Clients/AddClient',
			data: $scope.client
		}).then(function successCallback(response){
			alert("User has created Successfully")
		}, function errorCallback(response){
			alert("Error while created User");
		});
	};

});

//metodo para crear un usuario
