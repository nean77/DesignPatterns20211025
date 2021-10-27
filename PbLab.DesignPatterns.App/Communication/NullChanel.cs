using System.IO;

namespace PbLab.DesignPatterns.Communication
{
	internal class NullChanel : IChanel
	{
		public StreamReader Connect(string resource)
		{
			return StreamReader.Null;
		}
	}
}