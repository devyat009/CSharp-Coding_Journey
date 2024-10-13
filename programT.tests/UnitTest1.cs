using CSharpJourney;
using CSharpJourney._04;

namespace programT.tests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Expected True to 1")]
        public void Test1booleano()
        {
            bool result = Unitest.verdadeiro_ou_falso(1);
            Assert.True(true, "Expected return true for value 1");
        }

        [Fact(DisplayName = "Expected False to -1")]
        public void Test2booleano()
        {
            bool result = Unitest.verdadeiro_ou_falso(-1);
            Assert.False(result, "Expected return false for value -1");
        }
    }
}