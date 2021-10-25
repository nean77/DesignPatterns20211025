using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Services
{
	public interface IReaderFactory
	{
		ISamplesReader Create(string type);

		ISamplesReader Create(FileInfo type);
	}
}
