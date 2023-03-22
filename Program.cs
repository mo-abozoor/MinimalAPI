using MinimalAPI;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //ctrl .
        var Products = new List<Product>
{
    new Product
    {
        Id = "1",
        Name = "car",
        Description = "Description 1",
        Price = 1230,
        Quantity = "12 cars"
    },
     new Product
    {
        Id = "2",
        Name = "item",
        Description = "Description 2",
        Price = 55,
        Quantity = "32 item"
    },
      new Product
    {
        Id = "3",
        Name = "thing",
        Description = "Description 3",
        Price = 159,
        Quantity = "3 thing"
    },
};

        app.MapGet("/", () => "Hello World!");
        app.MapGet("/api/Products", () => Products);
        app.MapGet("/api/Products/{id}", (string id) =>
        {
            return Products.FirstOrDefault(c => c.Id == id);
        });
        app.MapPost("/api/Cars", (Product Product) =>
        {
            Products.Add(Product);
            return "Created";
        }
        );
        app.MapDelete("/api/Products/{id}", (string id) =>
        {
            var item = Products.FirstOrDefault(c => c.Id == id);
            bool v = Products.Remove(item);
            return v;

        });

        app.Run();
    }
}