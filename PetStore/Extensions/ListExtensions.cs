using PetStore.Data;

namespace PetStore
{
    public static class ListExtensions
	{
        public static List<T> IsInStock<T>(this List<T> list) where T : Product
        {
            return list.Where(x => x.Quantity > 0).ToList();
        }

    }
}

