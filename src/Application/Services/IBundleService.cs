using BundleCalculator.Contracts;

namespace BundleCalculator.Services
{
    public interface IBundleService
    {
        int ComputeFinishBundleAmountInStock(string bundleName);
    }
}