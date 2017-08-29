using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Helpers
{
    public static class FileReader
    {
        public static string AllText { get; private set; }

        public static string Read(string filePath)
        {
            AllText = System.IO.File.ReadAllText(filePath);
            return AllText;
        }
    }
}
