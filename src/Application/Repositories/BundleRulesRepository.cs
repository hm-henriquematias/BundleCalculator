using BundleCalculator.Contracts;
using BundleCalculator.DataContexts;

namespace BundleCalculator.Repositories
{
    public class BundleRulesRepository : IBundleRulesRepository
    {
        private readonly DataContext _context;

        public BundleRulesRepository(DataContext context)
        {
            _context = context;
        }

        public BundleRule FindByName(string bundleName)
        {
            return _context.BundleRules.FirstOrDefault(bundle => bundle.BundleName == bundleName);
        }
    }
}
