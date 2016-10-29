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

    $scope.Store = () =>
    {
        if (newResponse.url != null) {
            $http.post('/api/Response', newResponse)
                .success(function (response) {

                })
                .error(function (response) {

                })
            $("#outputTarget").append("<p>Response stored!</p>")
        }
    }

    $scope.Clear = () =>
    {
        $http.delete('/api/Response')
            .success(function (response) {
                $("#outputTarget").html("<p>All responses cleared.</p>")
            })
            .error(function (response) {
                $("#outputTarget").html("<p>Responses not cleared...</p>")
            })
    }
    $scope.ShowAll = () =>
    {
        console.log("showing");
        $http.get('/api/Response')
            .success(function (response) {
                console.log(response);
                for (SingleResponse in response)
                {
                    console.log(response[SingleResponse]);
                    $("#outputTarget").append("<p>Stored Response | URL: " + response[SingleResponse].URL + " status: " + response[SingleResponse].Code + " response time: " + response[SingleResponse].ResponseTime + "ms Date: "+ response[SingleResponse].SendDate + "</p>")
                }
            })
            .error(function (response) {
                $("#outputTarget").html("<p>Fetch error!</p>")
            })
    }

    $scope.MakeRequest = () => 
    {
        var now = new Date();
        var nowAsString = now.toISOString();
        var sendDate = now.getTime()
        $http({
            method: $scope.method,
            url: $scope.url,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            },
        }).then(function successCallback(response) {
            console.log(response.status);
            console.log(new Date().toISOString());
            var receiveDate = Date.now();
            var responseTimeInMs = receiveDate - sendDate;
            $("#outputTarget").html("<p>New Response | URL: " + $scope.url + " status: " + response.status + " response time: " + responseTimeInMs + "ms</p>");
            newResponse.url = $scope.url;
            newResponse.code = response.status;
            newResponse.method = $scope.method;
            newResponse.responseTime = responseTimeInMs;
            newResponse.sendDate = nowAsString;

        }, function errorCallback(response) {
            $("#outputTarget").html("<p>Unable to fetch response from that URL. Enter another.</p>")
        });
    }

});