module Models {
    export class MenuItem {

        constructor(
            public country: string,
            public id: number,
            public name: string,
            public description: string,
            public category: string,
            public price: number) { }

        public static parse(data: any): MenuItem {

            return new MenuItem(
                data.Country,
                data.Id,
                data.Name,
                data.Description,
                data.Category,
                data.price);
        }

        public static parseArray(data: any): MenuItem[] {
            return Enumerable.From(data).Select((item:any) => {
                return new MenuItem(
                    item.Country,
                    item.Id,
                    item.Name,
                    item.Description,
                    item.Category,
                    item.price
                    )
            }).ToArray();
        }
    }
} 