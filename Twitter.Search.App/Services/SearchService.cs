﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Twitter.Search.App.Models;

namespace Twitter.Search.App.Services
{
    public class SearchService : ISearchService
    {
        private HttpClient _client;
        private readonly AppSettings _appSettings;
        private string _authToken = null;

        public SearchService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            CreateTwitterClient();
        }

        private void CreateTwitterClient()
        {            
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.twitter.com/1.1/search/tweets.json"),
            };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_authToken ?? _appSettings.AuthorizeToken}");
            //_client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        private async Task GetAccessToken()
        {
            var authToken = Base64Encode($"{_appSettings.Consumer.Key}:{_appSettings.Consumer.Secret}");

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {authToken}");
            _client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");

            IList<KeyValuePair<string, string>> nameValueCollection = new List<KeyValuePair<string, string>> {
                { new KeyValuePair<string, string>("grant_type", "client_credentials") } };

            var result = await _client.PostAsync("https://api.twitter.com/oauth2/token", new FormUrlEncodedContent(nameValueCollection));

            TokenModel tm = JsonConvert.DeserializeObject<TokenModel>(await result.Content.ReadAsStringAsync());

            _authToken = tm.AccessToken;
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public async Task<string> GetData(string q)
        {
            var result = await _client.GetStringAsync(q);
            return result;
        }
    }
}
