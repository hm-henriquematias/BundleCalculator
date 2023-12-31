using BundleCalculator.Contracts;
using BundleCalculator.Repositories;

namespace BundleCalculator.Services
{
    public class BundleService : IBundleService
    {
        private IBundleRulesRepository _bundleRulesRepository;
        private IItemsRepository _itemsRepository;

        public BundleService(IBundleRulesRepository bundleRulesRepository, IItemsRepository itemsRepository)
        {
            _bundleRulesRepository = bundleRulesRepository;
            _itemsRepository = itemsRepository;
        }

        public int ComputeFinishBundleAmountInStock(string bundleName)
        {
            var finishedBundlesAmount = 0;

            var rule = _bundleRulesRepository.FindByName(bundleName);

            if (rule != null)
            {
                var itemGoals = (from item in rule.RequiredItems
                                 let availableItemsAmount = CountItemInStock(item)
                                 select GetAssembliesByBundleRule(availableItemsAmount, item.Amount)).ToList();

                finishedBundlesAmount = itemGoals.Min();
            }

            return finishedBundlesAmount;
        }

        private int CountItemInStock(Item item)
        {
            var bundleItem = _bundleRulesRepository.FindByName(item.Name);

            return bundleItem != null
                ? ComputeFinishBundleAmountInStock(bundleItem.BundleName)
                : _itemsRepository.CountItemsAvailable(item.Name);
        }

        private int GetAssembliesByBundleRule(int availableItemsAmount, int bundleRule)
        {
            return availableItemsAmount / bundleRule;
        }
    }
}