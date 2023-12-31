using BundleCalculator.Contracts;

namespace BundleCalculator.Repositories
{
    public interface IItemsRepository
    {
        Item FindByName(string itemName);
        int CountItemsAvailable(string itemName);
    }
}
