using BundleCalculator.Contracts;

namespace BundleCalculator.Repositories
{
    public interface IBundleRulesRepository
    {
        BundleRule FindByName(string bundleName);
    }
}
