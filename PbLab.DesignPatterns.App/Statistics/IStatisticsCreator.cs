using PbLab.DesignPatterns.Model;
using System;

namespace PbLab.DesignPatterns.Statistics
{
	// visitator contract
	public interface IStatisticsCreator
	{	
		// duplicates method for each type beeing visited
		void Analyze(Sample sample);
	}
}