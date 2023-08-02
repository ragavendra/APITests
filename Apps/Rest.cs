using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Apps
{

    public abstract class Rest
    {
        protected string _url;

        protected string _message;

        protected string auth;

        public (HttpStatusCode status, string response) Get()
        {
            var asyncTask = HttpGetAsync();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> HttpGetAsync()
        {
            using var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.GetAsync(_url);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Post()
        {
            var asyncTask = HttpPostAsync(_message);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> HttpPostAsync(string request)
        {
            using var client = new HttpClient();
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.PostAsync(_url, content);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Put()
        {
            var asyncTask = HttpPutAsync(_message);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> HttpPutAsync(string request)
        {
            using var client = new HttpClient();
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.PutAsync(_url, content);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Delete()
        {
            var asyncTask = HttpDeleteAsync();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> HttpDeleteAsync()
        {
            using var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.DeleteAsync(_url);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}