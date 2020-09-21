using SJ.Api.Core.Context;
using SJ.Api.Core.Model;
using SJ.Api.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ.Api.Core.Repository
{
    public class InsuranceRepository : BaseRepository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(SJApiContext context) : base(context) { }
    }
}
