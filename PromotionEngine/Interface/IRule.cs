using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Interface
{
    public interface IRule
    {
        int Execute(IEnumerable<Sku> skus);
    }
}
