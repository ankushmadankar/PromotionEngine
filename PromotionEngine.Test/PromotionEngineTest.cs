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

            Dictionary<Sku, int> skuValues = new Dictionary<Sku, int>()
            {
                {skuA, 1},
                {skuB, 1},
                {skuC, 1}
            };

            int result = engine.Execute(skuValues);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void ScenarioTwo()
        {
            Engine engine = GetEngine();

            Sku skuA = new Sku("A", 50);
            Sku skuB = new Sku("B", 30);
            Sku skuC = new Sku("C", 20);

            Dictionary<Sku, int> skuValues = new Dictionary<Sku, int>()
            {
                {skuA, 5},
                {skuB, 5},
                {skuC, 1}
            };

            int result = engine.Execute(skuValues);

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

            Dictionary<Sku, int> skuValues = new Dictionary<Sku, int>()
            {
                {skuA, 3},
                {skuB, 5},
                {skuC, 1},
                {skuD, 1}
            };

            int result = engine.Execute(skuValues);

            Assert.AreEqual(280, result);
        }

        private Engine GetEngine()
        {
            MultiplierRule ruleA = new MultiplierRule("A", 3, 130);
            MultiplierRule ruleB = new MultiplierRule("B", 2, 45);
            AlliesRule ruleCD = new AlliesRule("C", "D", 30);

            Engine engine = new Engine(new List<IRule> { ruleA, ruleB, ruleCD });

            return engine;
        }
    }
}
