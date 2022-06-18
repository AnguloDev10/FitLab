using Fitlab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Response
{
    public class ExperienceResponse : BaseResponse<Experience>
    {
        public ExperienceResponse(Experience resource) : base(resource)
        {

        }

        public ExperienceResponse(string message) : base(message)
        {
        }
    }
}
