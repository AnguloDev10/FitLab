using Fitlab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Response
{
    public class DietResponse : BaseResponse<Diet>
    {
        public DietResponse(Diet resource) : base(resource)
        {
        }

        public DietResponse(string message) : base(message)
        {
        }
    }

}
