using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos
{
    public class ReqresSingleDto<T> : ReqresDto where T : class
    {
        public T Data { get; set; }
    }
}
