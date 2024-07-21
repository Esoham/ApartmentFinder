using System;
using ApartmentFinder.Models;
using ApartmentFinder.Services;
using ApartmentFinder.UI;

namespace ApartmentFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ui = new UserInterface();
            var search = new AdvancedSearch();
            var comparison = new PriceComparison();
            var notification = new NotificationManager();
            var priceOptimizer = new PriceOptimizationService();

            var apartmentFinder = new ApartmentFinder(ui, search, comparison, notification, priceOptimizer);
            apartmentFinder.Run();
        }
    }

    public class ApartmentFinder
    {
        private readonly UserInterface _ui;
        private readonly AdvancedSearch _search;
        private readonly PriceComparison _comparison;
        private readonly NotificationManager _notification;
        private readonly PriceOptimizationService _priceOptimizer;

        public ApartmentFinder(UserInterface ui, AdvancedSearch search, PriceComparison comparison, NotificationManager notification, PriceOptimizationService priceOptimizer)
        {
            _ui = ui;
            _search = search;
            _comparison = comparison;
            _notification = notification;
            _priceOptimizer = priceOptimizer;
        }

        public void Run()
        {
            _ui.DisplayMenu();
            var listings = _search.SearchByCriteria("Sample Location", 1000m, 2, 1);
            _comparison.ComparePrices(listings);

            var tips = _priceOptimizer.GeneratePriceOptimizationTips(listings);
            foreach (var tip in tips)
            {
                _ui.DisplayMessage(tip);
            }

            _priceOptimizer.OptimizePrices(listings);

            foreach (var listing in listings)
            {
                _ui.DisplayMessage($"Address: {listing.Address}, Price: {listing.Price}");
            }

            _notification.SendNotification("New listing available!");
        }
    }
}