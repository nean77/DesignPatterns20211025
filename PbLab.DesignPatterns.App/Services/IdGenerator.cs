using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Services
{
    public class IdGenerator
    {
        private int _last;
        private static IdGenerator _instance;

        public static IdGenerator Instance => _instance ?? (_instance = new IdGenerator());

        public int Next()
        {
            return ++_last;
        }
    }
}
