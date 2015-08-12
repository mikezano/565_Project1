//http://davidwalsh.name/css-animation-callback
//http://brentvatne.ca/animation-obsession-and-ng-animate-1-3/
//https://www.youtube.com/watch?v=3hktBbxFxSM#t=69
module Web.Client {

    export class HomeController {

        public menuItems: Models.MenuItem[] = [];
        public selectedCountry: string = null;

        public static $inject = ['$http'];
        constructor(public $http:any) {
        }

        public getMenuItems(country: string): void {
            this.menuItems = [];
            this.selectedCountry = country;
            this.$http.get("/Home/GetMenuItems?country=" + country).then((result: any) => {
                this.menuItems = Models.MenuItem.parseArray(result.data);
                console.log(this.menuItems);
            });
        }
    }
}
app.registerController('Web.Client.HomeController', Web.Client.HomeController);
app.registerAngularUiRoute(Web.Client.HomeController, 'vm', "initial", "/", "app/views/home.html");

