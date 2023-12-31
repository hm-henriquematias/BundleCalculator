using BundleCalculator.Utils;

namespace Tests.UnitTests.Utils
{
    [TestClass]
    public class JsonHelperTest
    {
        [TestMethod]
        public void Read_WhenPathExists_ShouldBeSuccess()
        {
            var expected = "a"; 
            var readObject = JsonHelper.Read<TestMapAnonymousObject>("UnitTests\\Utils\\JsonHelperTest.json");
            Assert.AreEqual(expected, readObject.Property);
        }

        [TestMethod]
        public void Read_WhenPathNotExists_ShouldBeError()
        {
            var readObject = JsonHelper.Read<TestMapAnonymousObject>("UnitTests\\Utils\\JsonHelperTestWhenInvalid.json");
            Assert.IsNull(readObject);
        }

        [TestMethod]
        public void MapAnonymousObject()
        {
            var expected = "test";
            var readObject = JsonHelper.MapAnonymousObject<TestMapAnonymousObject>(new { Property= "test"});
            Assert.AreEqual(typeof(TestMapAnonymousObject), readObject.GetType());
            Assert.AreEqual(expected, readObject.Property);
        }

    }
        public class TestMapAnonymousObject
        {
            public string Property { get; set; }
        }
}