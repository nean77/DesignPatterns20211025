using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Validation
{
	public interface IValidator<T>
	{
		bool Validate(T item);
	}
}
