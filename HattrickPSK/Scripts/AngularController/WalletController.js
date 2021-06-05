myApp.controller("WalletController", function ($scope, $http) {
	
	$scope.events = [];
    
   //get all tickets of user
	$http.get('/Wallet/GetTicket')
        .then(function succesCallback(response) {
                      
            $scope.tickets = response.data;        
            
		}, function errorCallback(response) {

			alert("Error In data");
		});

    $scope.paymentTime = function (paymenttime) {
        
        //removing /Date from asp.net date 
        var date = new Date(parseInt(paymenttime.substr(6)));

        //getting date and time from date variable
        var min = date.getMinutes();
        if (min < 10) min = "0" + min;
        var hh = date.getHours();
        if (hh < 10) hh = "0" + hh;       
        var mm = date.getMonth();
        var dd = date.getDate();
        var yyyy = date.getFullYear();
        if (mm < 10) mm = "0" + mm;
        if (dd < 10) dd = "0" + dd;
        return "" + yyyy.toString() + "-" + mm + "-" + dd + "   " + hh + ":" + min;
        
    };

    //view what events are on ticket
    $scope.viewDetails = function (Choosen) {
        $scope.events.length = 0;

        
        for (i = 0; i < Choosen.length; i++) {
            $scope.events.push({
                EventID: Choosen[i].EventID,
                Type: Choosen[i].Event.Type,
                Name: Choosen[i].Event.Name,
                Choosen: Choosen[i].Tip
            });
        }


        $scope.eventNumber = $scope.events.length;


    };
});