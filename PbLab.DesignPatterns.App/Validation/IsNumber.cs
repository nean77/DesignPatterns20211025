using System.Linq;

namespace PbLab.DesignPatterns.Validation
{
	public class IsNumber : IValidator<string>
	{
		private IValidator<string> _next;

		public IsNumber(IValidator<string> next = null)
		{
			_next = next ?? new Terminator<string>();
		}

		public bool Validate(string item)
		{
			var unsigned = item.Trim().Trim('-');

			var hasNonNumber = unsigned.Any(symbol => symbol < 48 || symbol > 57);

			if (hasNonNumber)
			{
				return false;
			}

			return _next.Validate(item);
		}
	}
}
