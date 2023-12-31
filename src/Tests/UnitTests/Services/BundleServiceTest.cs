using NSubstitute;
using BundleCalculator.Contracts;
using BundleCalculator.Repositories;
using BundleCalculator.Services;

namespace Tests.UnitTests.Services
{
    [TestClass]
    public class BundleServiceTest
    {
        private readonly IBundleService _sut;

        private IBundleRulesRepository _bundleRulesRepository;
        private IItemsRepository _itemsRepository;

        public BundleServiceTest()
        {
            _bundleRulesRepository = Substitute.For<IBundleRulesRepository>();
            _itemsRepository = Substitute.For<IItemsRepository>();

            _sut = new BundleService(_bundleRulesRepository, _itemsRepository);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(3, 2, 1)]
        public void ComputeFinishBundleAmountInStockTest(int availableItemInStockAmount, int requiredItemAmountToBundle, int expectedFinishedBundlesAmount)
        {
            var item = new Item()
            {
                Name = "ItemToTest",
                Amount = availableItemInStockAmount,
            };

            var bundleRule = new BundleRule()
            {
                BundleName = "BundleToCalculate",
                RequiredItems = new List<Item>
                {
                    new Item()
                    {
                        Name = "ItemToTest",
                        Amount = requiredItemAmountToBundle,
                    }
                }
            };

            _bundleRulesRepository.FindByName("BundleToCalculate").Returns(bundleRule);
            _itemsRepository.FindByName("ItemToTest").Returns(item);
            _itemsRepository.CountItemsAvailable("ItemToTest").Returns(availableItemInStockAmount);

            Assert.AreEqual(expectedFinishedBundlesAmount, _sut.ComputeFinishBundleAmountInStock("BundleToCalculate"));
        }

        [DataTestMethod]
        [DataRow(50, 60, 60, 35, 17)]
        [DataRow(50, 60, 60, 0, 0)]
        [DataRow(0, 60, 60, 35, 0)]
        public void ComputeFinishBundleAmountInStockTest_WhenRequiredItemIsABundle(
            int seatAmountInStock,
            int pedalAmountInStock,
            int frameAmountInStock,
            int tubeAmountInStock,
            int expectedFinishedBundlesAmount)
        {
            // Bundle Rules
            var bikeBundleRule = new BundleRule()
            {
                BundleName = "Bike",
                RequiredItems = new List<Item>
                {
                    new Item()
                    {
                        Name = "Seat",
                        Amount = 1
                    },
                    new Item()
                    {
                        Name = "Pedal",
                        Amount = 2
                    },
                    new Item()
                    {
                        Name = "Wheel",
                        Amount = 2
                    }
                }
            };

            var wheelBundleRule = new BundleRule()
            {
                BundleName = "Wheel",
                RequiredItems = new List<Item>
                {
                    new Item()
                    {
                        Name = "Frame",
                        Amount = 1
                    },
                    new Item()
                    {
                        Name = "Tube",
                        Amount = 1
                    },
                }
            };

            // Available Items in stock
            var seat = new Item()
            {
                Name = "Seat",
                Amount = seatAmountInStock
            };
            var pedal = new Item()
            {
                Name = "Pedal",
                Amount = pedalAmountInStock
            };
            var frame = new Item()
            {
                Name = "Frame",
                Amount = frameAmountInStock
            };
            var tube = new Item()
            {
                Name = "Tube",
                Amount = tubeAmountInStock
            };

            _itemsRepository.FindByName("Seat").Returns(seat);
            _itemsRepository.FindByName("Pedal").Returns(pedal);
            _itemsRepository.FindByName("Frame").Returns(frame);
            _itemsRepository.FindByName("Tube").Returns(tube);
            
            _itemsRepository.CountItemsAvailable("Seat").Returns(seat.Amount);
            _itemsRepository.CountItemsAvailable("Pedal").Returns(pedal.Amount);
            _itemsRepository.CountItemsAvailable("Frame").Returns(frame.Amount);
            _itemsRepository.CountItemsAvailable("Tube").Returns(tube.Amount);

            _bundleRulesRepository.FindByName("Bike").Returns(bikeBundleRule);
            _bundleRulesRepository.FindByName("Wheel").Returns(wheelBundleRule);

            Assert.AreEqual(expectedFinishedBundlesAmount, _sut.ComputeFinishBundleAmountInStock("Bike"));
        }
    }
}
