using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Services
{
    internal class StatsBuilder
    {
        private readonly string _file;
        private TimeSpan _duration = TimeSpan.Zero;
        private uint _count = 0;

        public StatsBuilder(string file)
        {
            _file = file;
        }

        public SamplesReadStatistics Build()
        {
            return new SamplesReadStatistics(_file, _duration, _count);
        }

        public void AddDuration(TimeSpan duration)
        {
            _duration = duration;
        }

        public void AddCount(uint samplesCount)
        {
            _count = samplesCount;
        }
    }
}
