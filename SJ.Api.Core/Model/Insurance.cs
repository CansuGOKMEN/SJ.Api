using System;
using System.Collections.Generic;
using System.Text;

namespace SJ.Api.Core.Model
{
    public class Insurance : IEntityBase
    {
        public int Id { get; set; }
        public int ProductNo { get; set; }
        public int ProposalNo { get; set; } //Teklif No
        public int RenewalNo { get; set; } //Yenileme No
        public int EndorsNo { get; set; } //Zeyil No       
        public string? Result { get; set; }
        public DateTime Created { get => DateTime.Now; }
    }
}
