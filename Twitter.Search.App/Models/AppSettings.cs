﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Search.App.Models
{
    public class AppSettings
    {
        public Consumer Consumer { get; set; }
        public string AuthorizeToken { get; set; }
        public string HashTag { get; set; }
    }

    /// <summary>
    /// https://developer.twitter.com/en/apps/APP_ID
    /// </summary>
    public class Consumer
    {
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
