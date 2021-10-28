namespace PbLab.DesignPatterns.Validation
{
	internal class Terminator<T> : IValidator<T>
	{
		public bool Validate(T item)
		{
			return true;
		}
	}
}
