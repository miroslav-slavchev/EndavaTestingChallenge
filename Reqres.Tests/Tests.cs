using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Reqres.Library.Entities;
using Reqres.Library.Entities.Dtos.User;
using Reqres.Tests.APICLient;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Tests
{
    [SetUpFixture]
    public abstract class Tests
    {
        private const string ConfigFileName = "settings.json";

        // protected RestClient APIClient { get; private set; }
        protected ReqresAPIClient APIClient { get; private set; }

        protected Configuration Configuration { get; private set; }

        protected JsonFileReaderFacade JsonFileReader { get; } = new();

        [OneTimeSetUp]
        public void InitialiseClient()
        {
            
            Configuration = JsonFileReader.GetJObjectFromFile(ConfigFileName).ToObject<Configuration>();
            APIClient = new ReqresAPIClient(Configuration.AppUrl);
            APIClient.UseNewtonsoftJson();
        }
    }
}
