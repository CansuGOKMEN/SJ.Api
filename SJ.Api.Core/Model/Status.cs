using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ.Api.Core.Model
{
    public class Status : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
