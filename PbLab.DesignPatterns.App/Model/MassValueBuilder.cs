using PbLab.DesignPatterns.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Model
{
    internal class MassValueBuilder : IMassValueBuilder
    {
        private decimal _value;
        private MassUnit _unit;
		private NotEmpty _valueValidator;

		public MassValueBuilder()
		{
            _valueValidator = new NotEmpty(new IsNumber(new Positive(new Lenght(2))));
		}


        public void AddValue(string value)
        {
            var isValid = _valueValidator.Validate(value);

            if (!isValid)
            {
                throw new ArgumentOutOfRangeException("mass must be positive");
            }

            _value = decimal.Parse(value);
        }

        public void AddUnit(string unit)
        {
            _unit = (MassUnit)Enum.Parse(typeof(MassUnit), unit);
        }

        public MassValue Build()
        {
            return new MassValue(_value, _unit);
        }
    }
}
