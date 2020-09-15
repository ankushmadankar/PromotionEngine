using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model
{
    public class Sku
    {
		private string name;
		private int skuValue;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int SkuValue
		{
			get { return skuValue; }
			set { skuValue = value; }
		}
	}
}
