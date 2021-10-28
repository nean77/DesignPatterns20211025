namespace PbLab.DesignPatterns.Validation
{
	public abstract class Validator<T> : IValidator<T>
	{
		private IValidator<T> _next;

		protected Validator(IValidator<T> next = null)
		{
			_next = next ?? new Terminator<T>(); 
		}

		public bool Validate(T item)
		{
			var isBroken = IsBroken(item);

			if (isBroken)
			{
				return false;
			}

			return _next.Validate(item);
		}

		protected abstract bool IsBroken(T item);		
	}
}
