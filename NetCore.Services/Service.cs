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

        #region Constructor

        public Service(string url)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation(
                name: ServiceResource.UserAgent, value: ServiceResource.UserAgentType);
            client.BaseAddress = new Uri(url);
        }
        #endregion

        public async Task<object> Post<T>(T data) => await ServiceCall(method: "POST", body: data, id: "Hello");

        public async Task<object> Put<T>(string id, T data) => await ServiceCall(method: "PUT", body: data, id: id);

        public async Task<object> Get(string id = null) => await ServiceCall(method: "GET", body: false, id: id);

        public async Task<object> Delete(string id) => await ServiceCall(method: "DELETE", body: false, id: id);

        #region ServiceCall 
        public async Task<object> ServiceCall<T>(string method, T body, string id = null)
        {

            HttpResponseMessage response = null;
            string content = null;

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
        public StringContent GetStringContent<T>(T body)
        {
            return new StringContent(
                content: JsonConvert.SerializeObject(body),
                encoding: Encoding.UTF8,
                mediaType: "application/json");
        }
        #endregion

    }
}
