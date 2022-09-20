using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Tests.APICLient.Controllers
{
    public class AppUrl
    {
        public string BaseUrl { get; set; }

        public string Api { get; set; } = "api/";

        public string Version { get; set; } = string.Empty;

        public string FullUrl => $"{BaseUrl}{Api}{Version}";
    }
}
