app.controller("FormCtrl", function ($scope,$http) {

    $scope.url = "";

    $scope.method = "";

    $scope.response = {
        url: "",
        method: "",
        responsetime: ""
    };

    $scope.MakeRequest = () => 
    {
        $http({
            method: $scope.method,
            url: $scope.url,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
        },
        }).then(function successCallback(response) {
            console.log(response);
        }, function errorCallback(response) {
            console.log("error");
        });
    }

});