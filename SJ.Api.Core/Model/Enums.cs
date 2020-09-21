using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SJ.Api.Core.Model
{
    public class Enums
    {
        public enum Error
        {
            [Description("GeneralException")]
            GeneralException = 500,
            [Description("ApiClient")]
            ApiClient = 501
        }
    }
}
