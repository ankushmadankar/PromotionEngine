using System.Linq;
using PromotionEngine.Interface;
using PromotionEngine.Model;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class AlliesRule : IRule
    {
        /// <summary>
        /// Create instance for allies rule.
        /// </summary>
        /// <param name="ally1"></param>
        /// <param name="ally2"></param>
        /// <param name="promotionPrice"></param>
        public AlliesRule(string ally1, string ally2, int promotionPrice)
        {
            Ally1 = ally1;
            Ally2 = ally2;
            PromotionPrice = promotionPrice;
        }

        public string Ally1 { get; }

        public string Ally2 { get; }

        public int PromotionPrice { get; }

        public int Execute(IReadOnlyDictionary<Sku, int> skus)
        {
            int sum = 0;

            KeyValuePair<Sku, int> currentSkusAlly1 = skus.FirstOrDefault(a => a.Key != null && a.Key.Name == Ally1);
            KeyValuePair<Sku, int> currentSkusAlly2 = skus.FirstOrDefault(a => a.Key != null && a.Key.Name == Ally2);

            if (currentSkusAlly1.IsDefault() && currentSkusAlly2.IsDefault())
                return sum;
            
            if (!currentSkusAlly1.IsDefault() && currentSkusAlly2.IsDefault())
            {
                //If we found Ally 1 only not ally 2, e.g. C = 1 & D = 0.
                sum += currentSkusAlly1.Key.SkuValue * currentSkusAlly1.Value;
            }
            else if (currentSkusAlly1.IsDefault() && !currentSkusAlly2.IsDefault())
            {
                //If we found Ally 2 only not ally 1, e.g. C = 0 & D = 1.
                sum += currentSkusAlly2.Key.SkuValue * currentSkusAlly2.Value;
            }
            else
            {
                //If we found Ally 1 & ally 1, e.g. C = 2 & D = 1.
                int ally1Count = currentSkusAlly1.Value;
                int ally2Count = currentSkusAlly2.Value;

                if(ally1Count > ally2Count)
                {
                    sum += ally2Count * PromotionPrice;
                    sum += (ally1Count - ally2Count) * currentSkusAlly1.Key.SkuValue;
                }
                else
                {
                    sum += ally1Count * PromotionPrice;
                    sum += (ally2Count - ally1Count) * currentSkusAlly2.Key.SkuValue;
                }
            }

            return sum;
        }
    }
}
