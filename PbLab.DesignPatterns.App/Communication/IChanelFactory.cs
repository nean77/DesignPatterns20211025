using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Communication
{
    public interface IChanelFactory
    {
        IChanel Create(string protocol);
    }
}
