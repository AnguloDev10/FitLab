using Fitlab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Response
{
    public class SessionResponce : BaseResponse<Session>
    {
        public SessionResponce(Session resource) : base(resource)
        {
        }

        public SessionResponce(string message) : base(message)
        {
        }
    }
}
