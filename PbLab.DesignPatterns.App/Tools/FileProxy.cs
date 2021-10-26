using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Tools
{
    internal class FileProxy
    {
        public static StreamReader OpenText(string file)
        {
            return File.Exists(file) == false ? StreamReader.Null : File.OpenText(file);
        }
    }
}
