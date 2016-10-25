app.controller("FormCtrl", function ($scope, $http) {

    $scope.url = "";

    $scope.method = "";

    var newResponse = {
        url: "",
        method: "",
        responsetime: ""
    };

    $scope.MakeRequest = () => 
    {
        var sendDate = (new Date()).getTime();
        $http({
            method: $scope.method,
            url: $scope.url,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            },
        }).then(function successCallback(response) {
            console.log(response);
            var receiveDate = (new Date()).getTime();
            var responseTimeInMs = receiveDate - sendDate;
            $('#outputTarget').append("<br>URL: "+ $scope.url+" status: " + response.status + " response time: " + responseTimeInMs);

        }, function errorCallback(response) {
            console.log("error");
        });
    }

});