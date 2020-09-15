using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MultiplierRule ruleA = new MultiplierRule("A", 3);
            MultiplierRule ruleB = new MultiplierRule("B", 3);
        }
    }
}
