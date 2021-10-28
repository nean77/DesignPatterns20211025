namespace PbLab.DesignPatterns.Validation
{
	public class Lenght : Validator<string>
	{
		private int _maxLenght;

		public Lenght(int maxLenght, IValidator<string> next = null)
			: base(next)
		{
			_maxLenght = maxLenght;
		}

		protected override bool IsBroken(string item)
		{
			return item.Length > _maxLenght;
		}
	}
}
