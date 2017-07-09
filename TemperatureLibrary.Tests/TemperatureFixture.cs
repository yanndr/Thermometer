using Xunit;

namespace TemperatureLibrary.Tests
{
    public class TemperatureFixture
    {

        [Fact] 
        public void EqualOperatorPositive()
        {
            var input1 = new Temperature(10m,Unit.Celsius);
            var input2 = new Temperature(10m,Unit.Celsius);

            Assert.True(input1==input2);
        }

        [Fact] 
        public void EqualOperatorNegativeWithSameUnit()
        {
            var input1 = new Temperature(15m,Unit.Celsius);
            var input2 = new Temperature(10m,Unit.Celsius);

            Assert.False(input1==input2);
        }

        [Fact] 
        public void EqualOperatorNegativeWithDifferentUnit()
        {
            var input1 = new Temperature(10m,Unit.Fahrenheit);
            var input2 = new Temperature(10m,Unit.Celsius);

            Assert.False(input1==input2);
        }

        [Fact] 
        public void NotEqualOperatorNegative()
        {
            var input1 = new Temperature(10m,Unit.Celsius);
            var input2 = new Temperature(10m,Unit.Celsius);

            Assert.False(input1!=input2);
        }

        [Fact] 
        public void NotEqualOperatorPositiveWithSameUnit()
        {
            var input1 = new Temperature(15m,Unit.Celsius);
            var input2 = new Temperature(10m,Unit.Celsius);

            Assert.True(input1!=input2);
        }

        [Fact] 
        public void NotEqualOperatorPositiveWithDifferentUnit()
        {
            var input1 = new Temperature(10m,Unit.Fahrenheit);
            var input2 = new Temperature(10m,Unit.Celsius);

            Assert.True(input1!=input2);
        }

        [Fact] 
        public void ObjectEqualOperatorPositive()
        {
            var input1 = new Temperature(10m,Unit.Fahrenheit);
            var input2 = input1;

            Assert.True(input1.Equals(input2));
        }

        [Fact] 
        public void ObjectEqualOperatorNegative()
        {
            var input1 = new Temperature(10m,Unit.Fahrenheit);
            var input2 = new Temperature(10m,Unit.Fahrenheit);

            Assert.False(input1.Equals(input2));
        }
    }
}