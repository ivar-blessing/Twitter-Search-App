using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Twitter.Search.App.Models;
using Twitter.Search.App.Services;

namespace Twitter.Search.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ISearchService _searchService;

        public HomeController(IOptions<AppSettings> options, ISearchService searchService)
        {
            _appSettings = (AppSettings)options.Value;
            _searchService = searchService;
        }

        public IActionResult Index(string ht)
        {
            ViewData["HashTag"] = ht;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [ResponseCache(Duration = 300, VaryByQueryKeys = new string[] {"ht"})]
        public JsonResult GetTweets(string ht = null)
        {
            var searchFor = ht ?? _appSettings.HashTag;

            var query = $"?q=%23{searchFor}&result_type=recent";

            var result = QueryTweets(query);

            return Json(result);
        }

        private List<Status> QueryTweets(string query)
        {
            var userStatusCollection = new List<Status>();
            var userStatusQuery = _searchService.GetData(query).Result;
            var userStatusObj = JsonConvert.DeserializeObject<TweetSearchResponse>(userStatusQuery);
            userStatusCollection.AddRange(userStatusObj.Statuses.Where(x => x.RetweetedStatus == null)); //  filter out retweets

            if (string.IsNullOrEmpty(userStatusObj.SearchMetadata?.NextResults))
                return userStatusCollection;
            else
                userStatusCollection.AddRange(QueryTweets($"{userStatusObj.SearchMetadata.NextResults}&tweet_mode=extended"));

            return userStatusCollection;
        }

    }
}
