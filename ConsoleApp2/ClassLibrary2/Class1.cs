using NUnit.Framework;
using Calculator;
namespace Calculator.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void shouldaddTwoNumbers()
        {
            var c = new Calculator();
            var result = c.Add(2, 3);

            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void shouldmultiplyTwoNumbers()
        {
            var c = new Calculator();
            var result = c.Multiply(2, 3);

            Assert.That(result, Is.EqualTo(6));

        }
    }
}
