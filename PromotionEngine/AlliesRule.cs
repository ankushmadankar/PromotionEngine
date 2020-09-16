using PromotionEngine.Interface;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine
{
    public class AlliesRule : IRule
    {
        public AlliesRule(string ally1, string ally2, int promotionPrice)
        {
            Ally1 = ally1;
            Ally2 = ally2;
            PromotionPrice = promotionPrice;
        }

        public string Ally1 { get; }

        public string Ally2 { get; }

        public int PromotionPrice { get; }

        public int Execute(IEnumerable<Sku> skus)
        {
            int sum = 0;

            var currentSkusAlly1 = skus.Where(a => a.Name == Ally1);
            var currentSkusAlly2 = skus.Where(a => a.Name == Ally2);

            if (!currentSkusAlly1.Any() && !currentSkusAlly2.Any())
                return sum;

            if (!currentSkusAlly1.Any() && currentSkusAlly2.Any())
            {
                sum += currentSkusAlly2.First().SkuValue * currentSkusAlly2.Count();

            }
            else if (currentSkusAlly1.Any() && !currentSkusAlly2.Any())
            {
                sum += currentSkusAlly1.First().SkuValue * currentSkusAlly1.Count();
            }
            else
            {
                int ally1Count = currentSkusAlly1.Count();
                int ally2Count = currentSkusAlly2.Count();

                if(ally1Count > ally2Count)
                {
                    sum += ally2Count * PromotionPrice;
                    sum += (ally1Count - ally2Count) * currentSkusAlly1.First().SkuValue;
                }
                else
                {
                    sum += ally1Count * PromotionPrice;
                    sum += (ally2Count - ally1Count) * currentSkusAlly2.First().SkuValue;
                }
            }

            return sum;
        }
    }
}
