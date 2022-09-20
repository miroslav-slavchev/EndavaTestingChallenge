using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Library.Entities.Dtos.Resource
{
    public class ResourceDataDto
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        [JsonProperty("pantone_value")]
        public string PantoneValue { get; set; }
    }
}
