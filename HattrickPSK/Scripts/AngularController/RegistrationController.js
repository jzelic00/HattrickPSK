var myApp = angular.module('myApp', []);

myApp.controller('registrationCtrl', function ($scope, $http, $window) {



    $scope.user = {};
    var status = {};

    $scope.savedata = function (user) {


        $http.post("/Registration/SaveUser", { newUser: user })
            .then(function succesCallback(response) {
                status = response.data;
                if (status === 0) {
                    alert("Registration successfull");
                    $window.location.href = "/Login/Index";
                }
                else if (status === 1) {
                    alert("Username is already in use");
                }
                else if (status === 2) {
                    alert("Email is already in use");
                }
               

            }, function errorCallback(response) {
                alert("POST method error");
            });

    };

});