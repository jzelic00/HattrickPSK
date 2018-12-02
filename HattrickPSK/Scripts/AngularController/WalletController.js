myApp.controller("WalletController", function ($scope, $http) {


	var ticket = {};
	$scope.events = [];

	$http.get('/Wallet/GetTicket')
		.then(function succesCallback(response) {
			console.log(response.data);
			$scope.tickets = response.data;
		}, function errorCallback(response) {

			alert("Error In data");
		});

	$scope.viewDetails = function (Events, Choosen) {
		$scope.events.length = 0;

		console.log($scope.events.length);
		for (i = 0; i < Events.length; i++) {
			$scope.events.push({
				EventID: Events[i].EventID,
				Type: Events[i].Type,
				Name: Events[i].Name,
				Choosen: Choosen[i],
			});
		}


		$scope.eventNumber = $scope.events.length;
		console.log($scope.events.length);
	}
});