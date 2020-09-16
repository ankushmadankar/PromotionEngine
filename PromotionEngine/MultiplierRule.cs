using System.Linq;
using PromotionEngine.Interface;
using PromotionEngine.Model;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class MultiplierRule : IRule
    {
        /// <summary>
        /// Create instance of multipler rule.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="multiplier"></param>
        /// <param name="promotionPrice"></param>
        public MultiplierRule(string name, int multiplier, int promotionPrice)
        {
            Name = name;
            Multiplier = multiplier;
            PromotionPrice = promotionPrice;
        }

        public string Name { get; }

        public int Multiplier { get; }

        public int PromotionPrice { get; }

        public int Execute(IReadOnlyDictionary<Sku, int> skus)
        {
            int sum = 0;

            if (skus == null || !skus.Any())
                return sum;

            KeyValuePair<Sku, int> currentSkus = skus.FirstOrDefault(a => a.Key != null && a.Key.Name == Name);

            if (currentSkus.IsDefault())
                return sum;

            int skuValue = currentSkus.Key.SkuValue;
            int count = currentSkus.Value;
            int divider = count / Multiplier;
            int remainder = count % Multiplier;

            //Multiple promotion price with divider of skus.
            if (divider > 0)
            {
                sum += divider * PromotionPrice;
            }

            //Add actual price of sku.
            if (remainder > 0)
            {
                sum += remainder * skuValue;
            }

            return sum;
        }
    }
}
