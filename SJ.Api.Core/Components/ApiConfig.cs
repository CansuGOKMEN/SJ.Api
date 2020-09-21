using SJ.Api.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ.Api.Core.Components
{
    public class ApiConfig
    {
        public string Url { get; set; }
        public Authentication Authentication { get; set; }
    }
}
