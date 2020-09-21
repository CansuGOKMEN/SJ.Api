using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SJ.Api.Core.Model;
using static SJ.Api.Core.Model.Enums;

namespace SJ.Api.Core.Components
{
    public class ApiClient
    {
        private HttpClient client;
        private ApiConfig config;
        public ApiClient(ApiConfig config)
        {
            this.config = config;

            client = new HttpClient();
            client.BaseAddress = new Uri(config.Url);
        }

        private async Task<ApiResponse> Post(JToken data)
        {
            ApiResponse result = null;

            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = new HttpResponseMessage();
                response = await client.PostAsync(config.Url, content);

                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    result = new ApiResponse(responseBody);
                else
                {
                    result = new ApiResponse(Error.ApiClient);
                    result.data = response;
                }
                client.Dispose();
            }
            catch (Exception ex)
            {
                result = new ApiResponse(Error.ApiClient);
                result.data = ex;
            }

            return result;
        }

        public async Task<ApiResponse> AllInformation(Insurance insurance)
        {
            Root<Insurance> request = new Root<Insurance>()
            {
                Authentication = config.Authentication,
                Object = insurance
            };

            dynamic obj = new JObject();
            obj = JToken.FromObject(request);

            return await Post(obj);
        }

        public class Root<T>
        {
            public Authentication Authentication { get; set; }
            public T Object { get; set; }
        }

    }
}
