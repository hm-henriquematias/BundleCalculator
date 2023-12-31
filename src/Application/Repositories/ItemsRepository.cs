using BundleCalculator.Contracts;
using BundleCalculator.DataContexts;

namespace BundleCalculator.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly DataContext _context;

        public ItemsRepository(DataContext context)
        {
            _context = context;
        }

        public int CountItemsAvailable(string itemName)
        {
            var item = FindByName(itemName);
            return item != null ? item.Amount : 0;
        }

        public Item FindByName(string itemName)
        {
            return _context.Items.FirstOrDefault(item => item.Name == itemName);
        }
    }
}
