using PromotionEngine.Interface;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class MultiplierRule : IRule
    {
        public MultiplierRule(string name, int multiplier, int promotionPrice)
        {
            Name = name;
            Multiplier = multiplier;
            PromotionPrice = promotionPrice;
        }

        public string Name { get; }

        public int Multiplier { get; }

        public int PromotionPrice { get; }

        public int Execute(IEnumerable<Sku> skus)
        {
            int sum = 0;

            if (skus == null || !skus.Any()) return sum;

            var currentSkus = skus.Where(a => a.Name == Name);

            if (!currentSkus.Any()) return sum;

            int skuValue = currentSkus.First().SkuValue;
            int count = currentSkus.Count();
            int divider = count / Multiplier;
            int remainder = count % Multiplier;

            if(divider > 0)
            {
                sum += divider * PromotionPrice;
            }

            if (remainder > 0)
            {
                sum += remainder * skuValue;
            }

            return sum;
        }
    }
}
