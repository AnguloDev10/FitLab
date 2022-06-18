using Fitlab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Response
{
    public class ProgressResponse : BaseResponse<Progress>
    {
        public ProgressResponse(Progress resource) : base(resource)
        {
        }

        public ProgressResponse(string message) : base(message)
        {
        }
    }
}
