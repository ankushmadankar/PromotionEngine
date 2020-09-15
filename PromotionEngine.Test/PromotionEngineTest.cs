using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interface;
using PromotionEngine.Model;
using System.Collections.Generic;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        public void ScenarioOne()
        {
            Engine engine = GetEngine();

            Sku skuA = new Sku("A", 50);
            Sku skuB = new Sku("B", 30);
            Sku skuC = new Sku("C", 20);

            int result = engine.Execute(new List<Sku> { skuA, skuB, skuC });

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void ScenarioTwo()
        {
            Engine engine = GetEngine();

            Sku skuA = new Sku("A", 50);
            Sku skuB = new Sku("B", 30);
            Sku skuC = new Sku("C", 20);

            int result = engine.Execute(new List<Sku> { skuA, skuA, skuA, skuA, skuA, skuB, skuB, skuB, skuB, skuB, skuC });

            Assert.AreEqual(370, result);
        }

        [TestMethod]
        public void ScenarioThree()
        {
            Engine engine = GetEngine();

            Sku skuA = new Sku("A", 50);
            Sku skuB = new Sku("B", 30);
            Sku skuC = new Sku("C", 20);
            Sku skuD = new Sku("D", 20);

            int result = engine.Execute(new List<Sku> { skuA, skuA, skuA, skuB, skuB, skuB, skuB, skuB, skuC, skuD });

            Assert.AreEqual(280, result);
        }

        private Engine GetEngine()
        {
            MultiplierRule ruleA = new MultiplierRule("A", 3);
            MultiplierRule ruleB = new MultiplierRule("B", 3);
            AlliesRule ruleCD = new AlliesRule("C", "D");

            Engine engine = new Engine(new List<IRule> { ruleA, ruleB, ruleCD });

            return engine;
        }
    }
}
