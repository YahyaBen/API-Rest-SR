using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Helper
{
    public class ClientApi
    {
        public HttpClient initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001"); 
            return client;
        }
    }
}

// https://www.youtube.com/watch?v=bgsROO8kDh0
// https://www.tutorialsteacher.com/webapi/consume-web-api-post-method-in-aspnet-mvc
// https://www.yogihosting.com/aspnet-core-api-controllers/#controllerbase
