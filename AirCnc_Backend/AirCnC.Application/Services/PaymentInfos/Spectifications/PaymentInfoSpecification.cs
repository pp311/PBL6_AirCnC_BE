using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.PaymentInfos.Spectifications
{
    public class PaymentInfoSpecification: Specification<PaymentInfo>
    {
        public PaymentInfoSpecification(int hostId)
        {
            AddFilter(p => p.HostId == hostId);
            AddInclude(p => p.Host);
        }
    }
}
