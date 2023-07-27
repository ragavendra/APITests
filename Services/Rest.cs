using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppName
{

    public abstract class Rest
    {
        protected string URLi, sMessage, auth;
        //protected JObject jMessage;

        public (HttpStatusCode status, string response) Get()
        {
            var asyncTask = httpGet();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpGet()
        {
            using var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.GetAsync(URLi);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Post()
        {
            var asyncTask = httpPost(sMessage);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpPost(string request)
        {
            using var client = new HttpClient();
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.PostAsync(URLi, content);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Put()
        {
            var asyncTask = httpPut(sMessage);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpPut(string request)
        {
            using var client = new HttpClient();
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.PutAsync(URLi, content);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Delete()
        {
            var asyncTask = httpDelete();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpDelete()
        {
            using var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.DeleteAsync(URLi);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}