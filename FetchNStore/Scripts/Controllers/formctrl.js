app.controller("FormCtrl", function ($scope, $location) {

    $scope.url = "";

    $scope.method = "";

    $scope.response = {
        url: "",
        method: "",
        responsetime: ""
    };

    $scope.MakeRequest = () => 
    {
        console.log($scope.url, $scope.method);
    }

});