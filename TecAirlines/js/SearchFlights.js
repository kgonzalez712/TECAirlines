// JavaScript source code
var URL = "192.168.100.20";
var myApp = angular.module('myApp', []);
myApp.controller("appController", function ($scope, $http) {
    $scope.buscarVuelo = true;
    $scope.reservarVuelo = false;
    $http.get("http://" + URL + "/TECAirlinesAPI/Airports").then(function (response) {
        $scope.places = response.data;
    });


    $scope.lookFlight = function () {
        alert($scope.flight.ORIGIN.IATA_CODE)
        $scope.flight.ORIGIN = $scope.flight.ORIGIN.IATA_CODE;
        $scope.flight.DESTINATION = $scope.flight.DESTINATION.IATA_CODE;
        $http.get("http://" + URL + '/TECAirlinesAPI/Flights/' + $scope.flight.ORIGIN + '/' + $scope.flight.DESTINATION).then(function (response) {
            $scope.vuelo = response.data;
            alert("Exitoso");
        });
        /*$http({
            method: 'POST',
            url: 'http://' + URL + '/TECAirlinesAPI/Flights/' + $scope.flight.ORIGIN + '/' + $scope.flight.DESTINATION,
            data: $scope.flight
        }).then(function successCallback(response) {
            alert("Buscando vuelos")
        }, function errorCallback(response) {
            alert("Error");
        });*/
    };
    $scope.buscar = function (flight) {
        $scope.flight = flight;
        $scope.buscarVuelo = false;
        $scope.reservarVuelo = true;
        $scope.flight.ORIGIN = $scope.flight.ORIGIN.IATA_CODE;
        $scope.flight.DESTINATION = $scope.flight.DESTINATION.IATA_CODE;
        $http.get("http://" + URL + '/TECAirlinesAPI/Flights/' + $scope.flight.ORIGIN + '/' + $scope.flight.DESTINATION).then(function (response) {
            $scope.vuelos = response.data;
            alert("Exitoso");
        });
    };

    $scope.reservar = function () {
        $scope.buscar = true;
        $scope.reservar = false;
    };
});