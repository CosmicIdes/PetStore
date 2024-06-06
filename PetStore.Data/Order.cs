using System;
namespace PetStore.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

