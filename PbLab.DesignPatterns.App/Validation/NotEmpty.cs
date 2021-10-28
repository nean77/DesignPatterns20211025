namespace PbLab.DesignPatterns.Validation
{
	public class NotEmpty : IValidator<string>
	{
		private IValidator<string> _next;

		public NotEmpty(IValidator<string> next = null)
		{
			_next = next ?? new Terminator<string>();
		}

		public bool Validate(string item)
		{
			var isEmpty = string.IsNullOrEmpty(item);

			if (isEmpty)
			{
				return false;
			}

			return _next.Validate(item);
		}
	}
}
