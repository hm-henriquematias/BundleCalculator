using BundleCalculator.Contracts;
using BundleCalculator.DataContexts;
using BundleCalculator.Repositories;

namespace Tests.UnitTests.Repositories
{
    [TestClass]
    public class BundleRulesRepositoryTest
    {
        private readonly IBundleRulesRepository _sut;

        private readonly BundleRule _bundleRuleToTest;

        public BundleRulesRepositoryTest()
        {
            _bundleRuleToTest = new BundleRule()
            {
                BundleName = "test",
                RequiredItems = new List<Item>()
                {
                    new Item()
                    {
                        Name = "test",
                        Amount = 1,
                    }
                }
            };

            var dataContext = new DataContext
            {
                BundleRules = new List<BundleRule>()
                {
                    _bundleRuleToTest
                }
            };

            _sut = new BundleRulesRepository(dataContext);
        }

        [TestMethod]
        public void FindByName_WhenItemExists_ShouldBeSuccess()
        {
            Assert.AreEqual(_bundleRuleToTest, _sut.FindByName("test"));
        }

        [TestMethod]
        public void FindByName_WhenItemNotExists_ShouldBeNull()
        {
            Assert.IsNull(_sut.FindByName("test1"));
        }
    }
}
