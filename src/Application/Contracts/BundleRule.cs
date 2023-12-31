namespace BundleCalculator.Contracts
{
    public class BundleRule
    {
        //public BundleRule(string bundle, Dictionary<string, int> requiredItems)
        //{
        //    BundleName = bundle;
        //    RequiredItems = new List<Item>();
        //    RequiredItems.AddRange(from item in requiredItems
        //                           select new Item()
        //                           {
        //                               Name = item.Key,
        //                               Amount = item.Value,
        //                           });
        //}

        public string BundleName { get; set; }
        public List<Item> RequiredItems { get; set; }
    }
}