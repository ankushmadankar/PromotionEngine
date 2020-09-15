using PromotionEngine.Interface;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class AlliesRule : IRule
    {
        public AlliesRule(string ally1, string ally2)
        {
            Ally1 = ally1;
            Ally2 = ally2;
        }

        public string Ally1 { get; }

        public string Ally2 { get; }

        public int Execute(IEnumerable<Sku> skus)
        {
            throw new NotImplementedException();
        }
    }
}
