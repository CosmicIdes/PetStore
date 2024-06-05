using System.Text.Json;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using PetStore;
using PetStore.Validators;

var services = CreateServiceCollection();

var productLogic = services.GetService<ProductLogic>();

MainOptions.MainOptionsList();

string userInput = Console.ReadLine();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a Product in JSON format");
        var userInputAsJson = Console.ReadLine();
        var dogLeash = JsonSerializer.Deserialize<Product>(userInputAsJson);
        ProductValidator validator = new ProductValidator();
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
        Console.Write("What is the id of the Product you would like to view? ");
        var id = int.Parse(Console.ReadLine());
        var product = productLogic.GetProductById(id);
        Console.WriteLine(JsonSerializer.Serialize(product));
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