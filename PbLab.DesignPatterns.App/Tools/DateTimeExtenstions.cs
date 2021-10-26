using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Tools
{
	public static class DateTimeExtenstions
	{
		public static string AsFileName(this DateTime time)
		{
			return "" + time.Year 
				      + time.Month 
					  + time.Day 
					  + time.Hour 
					  + time.Minute 
					  + time.Second; 
		}
	}
}
