namespace PetStore
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>();
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeash[name];
            }
            catch (Exception ex)
            {
                return null;
            }
                
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products.IsInStock().Select(x => x.Name).ToList();
        }


        public decimal GetTotalPriceOfInventory()
        {
            return _products.IsInStock().Select(x => x.Price).Sum();
        }
    }
    
}
