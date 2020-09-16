using PromotionEngine.Model;
using System.Collections.Generic;

namespace PromotionEngine.Interface
{
    public interface IRule
    {
        int Execute(IReadOnlyDictionary<Sku, int> skus);
    }
}
