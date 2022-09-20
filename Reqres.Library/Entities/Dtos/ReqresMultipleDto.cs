using Reqres.Library.Entities.Dtos.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos
{
    public class ReqresMultipleDto<T> : ReqresDto, IPaginationDto where T : class
    {
        public List<T> Data { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

        public int Total { get; set; }

        public int TotalPages { get; set; }
    }
}
