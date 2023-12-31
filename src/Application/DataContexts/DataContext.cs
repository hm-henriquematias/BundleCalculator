using BundleCalculator.Contracts;
using BundleCalculator.Utils;

namespace BundleCalculator.DataContexts
{
    public class DataContext
    {
        public List<Item> Items { get; set; }
        public List<BundleRule> BundleRules { get; set; }

        public DataContext()
        {
            
        }

        public DataContext(string dataJsonName)
        {
            var data = JsonHelper.Read<Dictionary<string, object>>(dataJsonName);
            Items = JsonHelper.MapAnonymousObject<List<Item>>(data.Where(data => data.Key == "Items").First().Value);
            BundleRules = JsonHelper.MapAnonymousObject<List<BundleRule>>(data.Where(data => data.Key == "BundleRules").First().Value);
        }
    }
}
