using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model
{
    public class Sku
    {
        public Sku(string name, int value)
        {
            Name = name;
            SkuValue = value;
        }

        /// <summary>
        /// Name of SKU
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Actual value/price of SKU.
        /// </summary>
        public int SkuValue { get; }
    }
}