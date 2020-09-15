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

        public string Name { get; }

        public int SkuValue { get; }
    }
}