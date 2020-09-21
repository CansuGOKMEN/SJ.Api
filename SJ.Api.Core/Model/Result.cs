using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ.Api.Core.Model
{
    public class Result : IEntityBase
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int InsuranceId { get; set; }
        public DateTime Created { get => DateTime.Now; }

        public Status Status { get; set; }
        public Insurance Insurance { get; set; }
    }
}
