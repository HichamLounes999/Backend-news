using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace newsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LatestNewsController : ControllerBase
    {

        private readonly ILogger<LatestNewsController> _logger;
        private readonly IMemoryCache _cache;

        public LatestNewsController(ILogger<LatestNewsController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<LatestNew> Get()
        {
            Random rnd = new Random();

            string[] simpleTitles = {
        "Breaking News",
        "Latest Update",
        "New Discovery",
        "Tech Innovation",
        "Market Trends",
        "Health Alert",
        "Sports Highlights",
        "Entertainment Buzz",
        "Political Insights",
        "Weather Report"
    };

            string[] simpleDescriptions = {
        "This just in a simple news about sport This just in a simple news about sport This just in a simple news about sport This just in a simple news about sport This just in a simple news about sport This just in a simple news about sport This just in a simple news about sport...",
        "Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates Here are the latest updates...",
        "Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings Discover the new findings...",
        "Check out the latest in tech Check out the latest in techtech Check out the latest in techtech Check out the latest in techtech Check out the latest in techtech Check out the latest in techtech Check out the latest in techtech Check out the latest in techtech Check out the latest in tech...",
        "Trends shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market shaping the market...",
        "Important health news Important health news Important health newsImportant health newsImportant health news Important health newsImportant health news Important health news...",
        "Highlights from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world from the sports world...",
        "Latest entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news entertainment news...",
        "Insights on political events on political events on political events on political events on political events on political events on political events on political events on political events on political events on political events...",
        "Your weather update weather update weather update weather update weather update weather update weather update weather update weather update weather update weather update weather update weather update weather update weather update..."
    };
            string[] simpleCategory = {
        "Local",
        "Global",
        "Breaking news",
        "World news",
        "Entertainment journalism",
        "Political journalism",
        "Weather forecasting",
        "Sport",
        "Tech – News",
        "Lifestyle – Family"
    };
            string[] simpleSources= {
        "BBC...",
        "France 24...",
        "Al Jazeera...",
        "Times Now...",
        "Fox News...",
        "Sky News...",
        "CNN...",
        "Al Arabiya...",
        "Zee News...",
        "CNN..."
    };

            var list =  Enumerable.Range(1, 30).Select(index => new LatestNew
            {
                id = rnd.Next().ToString(),
                Title = simpleTitles[rnd.Next(simpleTitles.Length)],
                Description = simpleDescriptions[rnd.Next(simpleDescriptions.Length)],
                Category = simpleCategory[rnd.Next(simpleCategory.Length)],
                Sources = simpleSources[rnd.Next(simpleSources.Length)]
            })
            .ToArray();
            _cache.Set("item1", list);

                 _cache.TryGetValue("item1", out IEnumerable<LatestNew> listing);
            return listing;
        }       
    }
}