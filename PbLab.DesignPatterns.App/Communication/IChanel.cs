using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Communication
{
    public interface IChanel
    {
        StreamReader Connect(string resource);
    }
}
