using PetStore;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Validators;
using FluentValidation.Results;

var services = CreateServiceCollection();

var productLogic = services.GetService<IProductLogic>();

MainOptions.MainOptionsList();

string userInput = Console.ReadLine();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a Dog Leash in JSON format");
        var userInputAsJson = Console.ReadLine();
        var dogLeash = JsonSerializer.Deserialize<DogLeash>(userInputAsJson);
        DogLeashValidator validator = new DogLeashValidator();
        ValidationResult result = validator.Validate(dogLeash);
        if(result.IsValid)
        {
            productLogic.AddProduct(dogLeash);
        }
        else
        {
            foreach(var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
        }
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