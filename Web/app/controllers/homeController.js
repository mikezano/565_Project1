//http://davidwalsh.name/css-animation-callback
//http://brentvatne.ca/animation-obsession-and-ng-animate-1-3/
//https://www.youtube.com/watch?v=3hktBbxFxSM#t=69
var Web;
(function (Web) {
    var Client;
    (function (Client) {
        var HomeController = (function () {
            function HomeController($http) {
                this.$http = $http;
                this.menuItems = [];
                this.selectedCountry = null;
            }
            HomeController.prototype.getMenuItems = function (country) {
                var _this = this;
                this.menuItems = [];
                this.selectedCountry = country;
                this.$http.get("/Home/GetMenuItems?country=" + country).then(function (result) {
                    _this.menuItems = Models.MenuItem.parseArray(result.data);
                    console.log(_this.menuItems);
                });
            };
            HomeController.$inject = ['$http'];
            return HomeController;
        })();
        Client.HomeController = HomeController;
    })(Client = Web.Client || (Web.Client = {}));
})(Web || (Web = {}));
app.registerController('Web.Client.HomeController', Web.Client.HomeController);
app.registerAngularUiRoute(Web.Client.HomeController, 'vm', "initial", "/", "app/views/home.html");
//# sourceMappingURL=homeController.js.map