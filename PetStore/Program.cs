using PetStore;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var services = CreateServiceCollection();

var productLogic = services.GetService<IProductLogic>();

MainOptions.MainOptionsList();

string userInput = Console.ReadLine();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        var dogLeash = new DogLeash();

        Console.WriteLine("Creating a dog leash...");

        Console.Write("Enter the material the leash is made out of: ");
        dogLeash.Material = Console.ReadLine();

        Console.Write("Enter the length in inches: ");
        dogLeash.LengthInches = int.Parse(Console.ReadLine());

        Console.Write("Enter the name of the leash: ");
        dogLeash.Name = Console.ReadLine();

        Console.Write("Give the product a description: ");
        dogLeash.Description = Console.ReadLine();

        Console.Write("Give the product a price in dollars: ");
        dogLeash.Price = decimal.Parse(Console.ReadLine());

        Console.Write("How many products do you have? ");
        dogLeash.Quantity = int.Parse(Console.ReadLine());

        productLogic.AddProduct(dogLeash);
        Console.WriteLine("Added a dog leash.");
    }
    if (userInput == "2")
    {
        Console.Write("What is the name of the dog leash you would like to view? ");
        var dogLeashName = Console.ReadLine();
        var dogLeash = productLogic.GetDogLeashByName(dogLeashName);
        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
        Console.WriteLine();
    }

    if (userInput == "3")
    {
        Console.WriteLine("The following products are in stock: ");
        var inStock = productLogic.GetOnlyInStockProducts();
        foreach (var item in inStock)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    if (userInput == "4")
    {
        Console.WriteLine($"The total price of inventory in stock is {productLogic.GetTotalPriceOfInventory()}");
        Console.WriteLine();
    }

    MainOptions.MainOptionsList();

    userInput = Console.ReadLine();
}

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .BuildServiceProvider();
}