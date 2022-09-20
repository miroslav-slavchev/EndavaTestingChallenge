using Reqres.Library.Entities.Dtos.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos
{
    public abstract class ReqresDto
    {
        public SupportDto Support { get; set; }
    }
}
