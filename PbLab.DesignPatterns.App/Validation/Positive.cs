namespace PbLab.DesignPatterns.Validation
{
	public class Positive : IValidator<string>
	{
		private IValidator<string> _next;

		public Positive(IValidator<string> next = null)
		{
			_next = next ?? new Terminator<string>();
		}

		public bool Validate(string item)
		{
			var isNegative = item.Trim().StartsWith("-");

			if (isNegative)
			{
				return false;
			}

			return _next.Validate(item);
		}
	}
}
