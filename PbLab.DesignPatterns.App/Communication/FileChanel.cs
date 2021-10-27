using PbLab.DesignPatterns.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Communication
{
    public class FileChanel : IChanel
    {
        public StreamReader Connect(string resource)
        {
            resource = resource.Replace("file://", "");
            return FileProxy.OpenText(resource);
        }
    }
}
