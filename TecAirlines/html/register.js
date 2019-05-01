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
	alert($scope.client.CLIENT_UID.UNIVERSITY_ID);
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