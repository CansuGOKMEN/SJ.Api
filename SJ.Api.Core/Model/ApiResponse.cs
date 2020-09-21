using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static SJ.Api.Core.Model.Enums;

namespace SJ.Api.Core.Model
{
    public class ApiResponse
    {
        public bool success { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic data { get; set; }
        public int statusCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public ApiResponse(dynamic resposeData)
        {
            success = true;
            data = resposeData;
            statusCode = 200;
            errorMessage = null;
        }

        public ApiResponse(Error error)
        {
            success = false;
            statusCode = (int)error;
            errorMessage = error.ToString();
        }
    }
}
