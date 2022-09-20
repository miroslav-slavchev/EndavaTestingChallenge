using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos.Pagination
{
    public interface IPaginationDto
    {
        public int Page { get; set; }

        [JsonProperty("Per_Page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("Total_Pages")]
        public int TotalPages { get; set; }
    }
}
