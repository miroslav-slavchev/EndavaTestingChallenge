using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.FilesFacades
{
    public static class JsonFileReaderFacade
    {
        public static JObject GetJObjectFromFile(string fileName)
        {
            string path = FileManager.GetFilePathFromBaseDirectory(fileName);
            string json = File.ReadAllText(path);
            return JObject.Parse(json);
        }

        public static JArray GetJArrayFromFile(string fileName)
        {
            string path = FileManager.GetFilePathFromBaseDirectory(fileName);
            string json = File.ReadAllText(path);
            return JArray.Parse(json);
        }

    }
}
