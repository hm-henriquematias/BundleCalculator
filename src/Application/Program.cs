using Microsoft.Extensions.DependencyInjection;
using BundleCalculator.DataContexts;
using BundleCalculator.Repositories;
using BundleCalculator.Services;

namespace BundleCalculator
{
    internal class Program
    {
        public static ServiceProvider ServiceProvider;
        public static DataContext Context = new("Data.json");

        static void Main(string[] args)
        {
            LoadServiceContainer();
            var bundleService = ServiceProvider.GetService<IBundleService>();
            var finishedBikesAmount = bundleService.ComputeFinishBundleAmountInStock("Bike");
            Console.WriteLine($"With the material in stock, it is possible to build: {finishedBikesAmount} bikes");
        }

        private static void LoadServiceContainer()
        {
            ServiceProvider = new ServiceCollection()
                .AddSingleton(Context)
                .AddTransient<IBundleRulesRepository, BundleRulesRepository>()
                .AddTransient<IItemsRepository, ItemsRepository>()
                .AddScoped<IBundleService, BundleService>()
                .BuildServiceProvider();
        }
    }
}