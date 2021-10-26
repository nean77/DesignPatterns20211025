using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Tools
{
	public interface IFactory<TType>
	{
		TType Create(string type);

		TType Create(FileInfo type);
	}
}
