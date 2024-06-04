namespace PetStore
{
    public interface IProductLogic
    {
        public void AddProduct(Product product);

        public List<Product> GetAllProducts();

        public Product GetProductById(int productId);
    }
}

