using NUnit.Framework;

namespace Atividade._04
{   
    public class UNTest01
    {
        public bool TrueTest(int value)
        {
            if (value >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // Tests
    [TestFixture]
    public class TestuN
    {
        [Test]
        public void test_true()
        {
            var UNTest = new UNTest01();
            var isTrue = UNTest.TrueTest(1);
            // Verify if is True
            //Assert.AreEqual(true, isTrue);
            Assert.That(isTrue, Is.EqualTo(true));
        }
        [Test]
        public void test_false()
        {
            var UNTest = new UNTest01();
            var isFalse = UNTest.TrueTest(-1);
            //Assert.AreEqual(false, isFalse);
            Assert.That(isFalse, Is.EqualTo(false));
        }
    }
}
