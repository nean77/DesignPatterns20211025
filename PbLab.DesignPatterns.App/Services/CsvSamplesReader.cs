using System;
using System.Collections.Generic;
using System.IO;
using PbLab.DesignPatterns.Model;

namespace PbLab.DesignPatterns.Services
{
    public class CsvSamplesReader: ISamplesReader
    {
        public IEnumerable<Sample> Read(StreamReader stream)
        {
            var results = new List<Sample>();
            var line = stream.ReadLine();
            while (string.IsNullOrEmpty(line) == false)
            {
                var parts = line.Split(';');

                var date = DateTimeOffset.Parse(parts[0]);
                var mass = MassValue.Parse(parts[1]);

                var sample = new Sample(date, mass);
                
                results.Add(sample);
                line = stream.ReadLine();
            }

            return results;
        }
	}
}