using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.FilesFacades
{
    public static class FileManager
    {

        public static string GetFilePathFromBaseDirectory(string fileName)
        {
            string dir = GetBaseDirectory();
            string filePath = $"{dir}\\{fileName}";
            return filePath;
        }

        public static string GetBaseDirectory()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(AppDomain.CurrentDomain.BaseDirectory);
            stringBuilder.Replace("\\bin\\Debug\\net6.0\\", "");
            return stringBuilder.ToString();
        }
    }
}
