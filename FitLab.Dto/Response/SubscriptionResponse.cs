using Fitlab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Response
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        public SubscriptionResponse(Subscription resource) : base(resource)
        {
        }

        public SubscriptionResponse(string message) : base(message)
        {
        }

    }
}
