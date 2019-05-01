// JavaScript source code
var URL = '172.18.120.69'
var myApp = angular.module('myApp', []);
myApp.controller("appController", function ($scope, $http) {
    $http.get("http://" + URL + "/TECAirlinesAPI/Clients/102580369").then(function (response) {
        $scope.client = response.data;
        //alert($scope.client[0].CLIENT_FNAME);
    });
    $http.get("http://" + URL + "/TECAirlinesAPI/Clients/102580369/CardNo").then(function (response) {
        $scope.card = response.data;
        //alert($scope.card);
    });

    $scope.updateUser = function () {
        $http({
            method: 'PUT',
            url: 'http://' + URL + 'direccionRest' + $scope.user.PersonalID + '/UpdateClient',
            data: $scope.user
        }).then(function successCallback(response) {
            alert("User has updated Successfully")
        }, function errorCallback(response) {
            alert("Error while updating user");
        });
    };
});
