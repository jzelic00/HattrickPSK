

myApp.controller("HomeController", function ($scope, $http) {


	var sportTypes = [0,0,0,0,0];
	var events = {};	
	var newEvent = {};	
	var deletingIndex = 0;
	var flag = 0;

	$scope.choosenEvents = [];
	$scope.totalOdds = 1;
	$scope.profit = 0;	
	$scope.betAmount = 0;
	$scope.bonus = 0;


	$http.get('/Home/GetEvents')
		.then(function succesCallback(response) {		
			$scope.events = response.data;
		}, function errorCallback(response) {
			alert("Error In data");
		});

	$scope.addChoosenEventToList = function (ListedEvent, ListedEventOdds, ListedEventTip) {

		newEvent.EventID = ListedEvent.EventID;
		newEvent.Type = ListedEvent.Type;
		newEvent.Name = ListedEvent.Name;
		newEvent.Tip = ListedEventTip;
		newEvent.Odds = ListedEventOdds;

			for (i = 0; i < $scope.choosenEvents.length; i++) {


				if ($scope.choosenEvents[i].EventID === ListedEvent.EventID) {
					$scope.totalOdds = Number.parseFloat(($scope.totalOdds / $scope.choosenEvents[i].Odds) * ListedEventOdds).toFixed(4);
			
					$scope.profitAmount();

					$scope.choosenEvents[i].Tip = ListedEventTip;
					$scope.choosenEvents[i].Odds = ListedEventOdds;

					return;
				}
			}
			$scope.choosenEvents.push(newEvent);

		$scope.totalOdds *= ListedEventOdds;
		$scope.totalOdds = Number.parseFloat($scope.totalOdds).toFixed(4);
		
		newEvent = {};
		
		$scope.profitAmount();

	}

	$scope.profitAmount = function () {

		$scope.profit = Number.parseFloat($scope.totalOdds * $scope.betAmount).toFixed(2);
	}

	$scope.deleteAllData = function () {

		$scope.choosenEvents.length = 0;
		$scope.totalOdds = 1;
		$scope.bonus = 0;
		$scope.betAmount = 0;
		$scope.profitAmount();
	}

	$scope.ticketPayment = function (choosenEvents) {

		$scope.bonusAddChecking(choosenEvents);

		$scope.deleteUnnecessaryPropertyForTicketSending(choosenEvents);

		$http.post('/Home/TicketRecive', { addTicket: choosenEvents, totalOdds: $scope.totalOdds, bonus: $scope.bonus, betAmount: $scope.betAmount, profit: $scope.profit}).
			then(function succesCallback(response) {
				if (response.status === 200) {

					$scope.choosenEvents.length = 0;

					alert("Ticket has been added\n\n" +
						"You get " + $scope.bonus+ " bonus \n" +
						"Total odds: " + $scope.totalOdds +
						"\nTotal profit amount: " + $scope.profit
					);
					
					$scope.deleteAllData();
					sportTypes = [0,0,0,0,0];
					$scope.betAmount = 0;
				}
			}), function errorCallback(response) {
				alert("Error in ticket upload, try later");
			};
		
		
	}

	$scope.deleteUnnecessaryPropertyForTicketSending = function (choosenEvents) {
	
		angular.forEach(choosenEvents, function (singleChoosenEvent) {
			delete singleChoosenEvent.Odds;
			delete singleChoosenEvent.Name;
			delete singleChoosenEvent.Type;
		});
	}

	$scope.DeleteSingleEvent = function (choosenEvent) {

		deletingIndex = $scope.choosenEvents.indexOf(choosenEvent);

		$scope.totalOdds = Number.parseFloat($scope.totalOdds / $scope.choosenEvents[deletingIndex].Odds).toFixed(4);
		$scope.profitAmount();
		
		$scope.choosenEvents.splice(deletingIndex, 1);
	}

	$scope.bonusAddChecking = function (choosenEvents) {
		
		if (choosenEvents.length < 2)
			return;
		else {
			for (i = 0; i < choosenEvents.length; i++) {
				switch (choosenEvents[i].Type) {

					case 'Football':
						sportTypes[0] += 1;
						break;
					case 'Basketball':
						sportTypes[1] += 1;
						break;
					case 'Box':
						sportTypes[2] += 1;
						break;
					case 'Handball':
						sportTypes[3] += 1;
						break;
					case 'Tenis':
						sportTypes[4] += 1;
						break;

				}
			}
					
		}

	
		$scope.addBonus5(sportTypes);
		$scope.addBonus10(sportTypes);
		
		$scope.totalOdds = (Number.parseFloat($scope.totalOdds) + $scope.bonus).toString();
		
		$scope.profitAmount();
	}

	
	$scope.addBonus5 = function (sportTypes) {
		$scope.calculateSportTypeBonusesForBonus5(sportTypes)
	}

	$scope.calculateSportTypeBonusesForBonus5 = function (sportTypes)
	{
	
		angular.forEach(sportTypes, function (singleSportType) {
			$scope.bonus += $scope.addBonusIfEligableForBonus5(singleSportType);
		});
	}

	$scope.addBonusIfEligableForBonus5 = function (singleSportType) {
	
		if (singleSportType < 3)
			return 0;

		return 5;
	}

	$scope.addBonus10 = function (sportTypes) {
		$scope.calculateSportTypeBonusesForBonus10(sportTypes)
	
	}

	$scope.calculateSportTypeBonusesForBonus10 = function(sportTypes)
	{		

		for (i = 0; i < sportTypes.length; i++)
			if ($scope.addBonusIfEligableForBonus10(sportTypes[i]) === 0) {
				flag = 1;
				break;
			}
				
		$scope.bonus += $scope.checkingFlagStatusForAddingBonus10(flag);
		
	}

	$scope.addBonusIfEligableForBonus10 = function (singleSportType) {
		if (singleSportType === 0)
			return 0;

		return 1;
	}

	$scope.checkingFlagStatusForAddingBonus10 = function(flag)
	{
		if (flag === 0)
			return 10;

		return 0;
	}
});