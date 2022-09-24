using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests
{
    public class Setttings
    {
        public string Url { get; set; }

        public string Browser { get; set; } = "Chrome";

        public BrowserResolution BrowserResolution { get; set; }
    }

    public class BrowserResolution
    {
        public int Width { get; set; }

        public int Height { get; set; }
    }
}
