using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Proxy.Controllers
{
    public class ProxyController : ApiController
    {
        [AcceptVerbs(WebRequestMethods.Http.Get, WebRequestMethods.Http.Head, WebRequestMethods.Http.MkCol,
             WebRequestMethods.Http.Post, WebRequestMethods.Http.Put)]
        public async Task<HttpResponseMessage> Proxy(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                this.Request.RequestUri = new Uri(url);

                var request = new HttpRequestMessage(Request.Method, url);
                

                //if (this.Request.Method == HttpMethod.Get)
                //{
                //    //this.Request.Content = null;
                //}

                return await http.SendAsync(request);
            }
        }
    }
}
