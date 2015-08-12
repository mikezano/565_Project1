var Models;
(function (Models) {
    var MenuItem = (function () {
        function MenuItem(country, id, name, description, category, price) {
            this.country = country;
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.price = price;
        }
        MenuItem.parse = function (data) {
            return new MenuItem(data.Country, data.Id, data.Name, data.Description, data.Category, data.price);
        };
        MenuItem.parseArray = function (data) {
            return Enumerable.From(data).Select(function (item) {
                return new MenuItem(item.Country, item.Id, item.Name, item.Description, item.Category, item.price);
            }).ToArray();
        };
        return MenuItem;
    })();
    Models.MenuItem = MenuItem;
})(Models || (Models = {}));
//# sourceMappingURL=menuItem.js.map