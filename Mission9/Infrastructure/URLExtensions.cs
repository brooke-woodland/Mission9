using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Infrastructure
{
    public static class URLExtensions
    {
        //make sure when you go back, you go back to shopping where you were before
        public static string PathAndQuery(this HttpRequest request) =>
        request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
     
    }
}
