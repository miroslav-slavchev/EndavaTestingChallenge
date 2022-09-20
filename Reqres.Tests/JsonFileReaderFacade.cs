using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Tests
{
    public class JsonFileReaderFacade
    {
        public JObject GetJObjectFromFile(string fileName)
        {
            string path = GetDirectory(fileName);
            string json = File.ReadAllText(path);
            return JObject.Parse(json);
        }

        public JArray GetJArrayFromFile(string fileName)
        {
            string path = GetDirectory(fileName);
            string json = File.ReadAllText(path);
            return JArray.Parse(json);
        }

        private static string GetDirectory(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(AppDomain.CurrentDomain.BaseDirectory);
            stringBuilder.Replace("\\bin\\Debug\\net6.0\\", "");
            stringBuilder.Append('\\');
            stringBuilder.Append(fileName);
            string path = stringBuilder.ToString();
            return path;
        }
    }
}
