app.controller("FormCtrl", function ($scope, $http) {

    $scope.url = "";

    $scope.method = "";

    var newResponse = {
        url: null,
        method: null,
        code: null,
        responseTime: null,
        sendDate: null
    };

    $scope.ApiGet = () =>
    {
        $http.post('/api/Response', { "name": "Jurnell", "class": "E3" })
            .success(function (response) {

            })
            .error(function (response) {

            })
    }

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
            $('#outputTarget').append("<br>URL: " + $scope.url + " status: " + response.status + " response time: " + responseTimeInMs + "ms");
            newResponse.url = $scope.url;
            newResponse.code = response.status;
            newResponse.method = $scope.method;
            newResponse.responseTime = responseTimeInMs;
            newResponse.sendDate = sendDate;

        }, function errorCallback(response) {
            console.log("error");
        });
    }

});