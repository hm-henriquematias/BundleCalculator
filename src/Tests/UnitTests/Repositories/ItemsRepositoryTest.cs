using BundleCalculator.Contracts;
using BundleCalculator.DataContexts;
using BundleCalculator.Repositories;

namespace Tests.UnitTests.Repositories
{
    [TestClass]
    public class ItemsRepositoryTest
    {
        private readonly IItemsRepository _sut;

        private readonly Item _itemToTest;

        public ItemsRepositoryTest()
        {
            _itemToTest = new Item()
            {
                Name = "test",
                Amount = 1,
            };
            var dataContext = new DataContext
            {
                Items = new List<Item>()
                {
                    _itemToTest
                }
            };
            _sut = new ItemsRepository(dataContext);
        }

        [TestMethod]
        public void FindByName_WhenItemExists_ShouldBeSuccess()
        {
            Assert.AreEqual(_itemToTest, _sut.FindByName("test"));
        }

        [TestMethod]
        public void FindByName_WhenItemNotExists_ShouldBeNull()
        {
            Assert.IsNull(_sut.FindByName("test1"));
        }

        [TestMethod]
        public void CountItemsAvailable_WhenItemSearchedExists_ShouldBeSuccess()
        {
            Assert.AreEqual(1, _sut.CountItemsAvailable("test"));
        }

        [TestMethod]
        public void CountItemsAvailable_WhenItemSearchedNotExists_ShouldBeZero()
        {
            Assert.AreEqual(0, _sut.CountItemsAvailable("test1"));
        }
    }
}
