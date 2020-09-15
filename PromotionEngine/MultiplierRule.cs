using PromotionEngine.Interface;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class MultiplierRule : IRule
    {
        public MultiplierRule(string name, int multiplier, int promotionPrice)
        {
            Name = name;
            Multiplier = multiplier;
        }

        public string Name { get; }

        public int Multiplier { get; }

        public int Execute(IEnumerable<Sku> skus)
        {
            throw new NotImplementedException();
        }
    }
}
