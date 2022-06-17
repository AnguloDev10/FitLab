using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Response
{
    internal class ResponseDto<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}
