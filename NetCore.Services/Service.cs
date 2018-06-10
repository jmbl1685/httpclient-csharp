using NetCore.Entities.Request;
using NetCore.Entities.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services
{
    public class Service
    {
        private readonly HttpClient client;

        public Service(string url)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation(
                name: ServiceResource.UserAgent, value: ServiceResource.UserAgentType);
            client.BaseAddress = new Uri(url);
        }

        public async Task<object> Post(Car data) => await ServiceCall(method: "POST", body: data);

        public async Task<object> Put(string id, Car data) => await ServiceCall(method: "PUT", body: data, id: id);

        public async Task<object> Get(string id = null) => await ServiceCall(method: "GET", id: id);

        public async Task<object> Delete(string id) => await ServiceCall(method: "DELETE", id: id);

        #region ServiceCall 
        public async Task<object> ServiceCall(string method, Car body = null, string id = null)
        {

            HttpResponseMessage response = null;
            string content = null;
            var car = JsonConvert.SerializeObject(body);

            try
            {
                switch (method)
                {
                    case "POST":
                        {
                            response = await client.PostAsync(client.BaseAddress, GetStringContent(body));
                            content = await response.Content.ReadAsStringAsync();
                            break;
                        }
                    case "GET":
                        {
                            if (id is null)
                                response = await client.GetAsync(client.BaseAddress);
                            else
                                response = await client.GetAsync($"{client.BaseAddress}/{id}");

                            content = await response.Content.ReadAsStringAsync();
                            break;
                        }
                    case "PUT":
                        {
                            response = await client.PutAsync($"{client.BaseAddress}/{id}", GetStringContent(body));
                            content = await response.Content.ReadAsStringAsync();
                            break;
                        }
                    case "DELETE":
                        {
                            response = await client.DeleteAsync($"{client.BaseAddress}/{id}");
                            content = await response.Content.ReadAsStringAsync();
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return content;
        }
        #endregion

        #region GetStringContent
        public StringContent GetStringContent(Car body)
        {
            return new StringContent(
                content: JsonConvert.SerializeObject(body),
                encoding: Encoding.UTF8,
                mediaType: "application/json");
        }
        #endregion

    }
}
