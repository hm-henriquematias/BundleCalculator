using BundleCalculator.DataContexts;
using BundleCalculator.Repositories;
using BundleCalculator.Services;

namespace Tests.IntegrationTests.Services
{
    [TestClass]
    public class BundleServiceTest
    {
        private readonly IBundleService _sut;

        public BundleServiceTest()
        {
            var context = new DataContext("DataToIntegrationTests.json");
            _sut = new BundleService(new BundleRulesRepository(context), new ItemsRepository(context));
        }

        [DataTestMethod]
        [DataRow("Bike", 17)]
        [DataRow("Wheel", 35)]
        public void ComputeFinishBundleAmountInStockTest(string bundleToCompute, int expectedFinishedBundlesAmount)
        {
            Assert.AreEqual(expectedFinishedBundlesAmount, _sut.ComputeFinishBundleAmountInStock(bundleToCompute));
        }
    }
}
