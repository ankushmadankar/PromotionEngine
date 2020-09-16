using PromotionEngine.Interface;
using PromotionEngine.Model;
using PromotionEngine.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PromotionEngine.UI
{
    public class MainWindowViewModel : PropertyObservable
    {
		public MainWindowViewModel()
		{
			//Command Action for user interaction.
			CalculateCommand = new RelayCommand<object>(obj => Calculate());
			ResetCommand = new RelayCommand<object>(obj => Reset());

			//Build promotion rule engine.
			engine = Engine.GetTestEngine();

			//Populate test values.
			PopulateTestValues();
		}

		public ICommand CalculateCommand { get; }

		public ICommand ResetCommand { get; }

		public int SkuAQuantity
		{
			get
			{
				return skuAQuantity;
			}
			set
			{
				skuAQuantity = value;
				base.OnPropertyChanged();
			}
		}

		public int SkuBQuantity
		{
			get
			{
				return skuBQuantity;
			}
			set
			{
				skuBQuantity = value;
				base.OnPropertyChanged();
			}
		}

		public int SkuCQuantity
		{
			get
			{
				return skuCQuantity;
			}
			set
			{
				skuCQuantity = value;
				base.OnPropertyChanged();
			}
		}

		public int SkuDQuantity
		{
			get
			{
				return skuDQuantity;
			}
			set
			{
				skuDQuantity = value;
				base.OnPropertyChanged();
			}
		}

		public int Result
		{
			get
			{
				return result;
			}
			set
			{
				result = value;
				base.OnPropertyChanged();
			}
		}

		private void Reset()
		{
			SkuAQuantity = 0;
			SkuBQuantity = 0;
			SkuCQuantity = 0;
			SkuDQuantity = 0;
			Result = 0;
		}

		private void Calculate()
		{
			//Build SKU pre-defined values.
			Dictionary<Sku, int> skusValue = new Dictionary<Sku, int>()
			{
				{ new Sku("A", 50), SkuAQuantity },
				{ new Sku("B", 30), SkuBQuantity },
				{ new Sku("C", 20), SkuCQuantity },
				{ new Sku("D", 20), SkuDQuantity }
			};

			Result = engine.Execute(skusValue);
		}

		private void PopulateTestValues()
		{
			SkuAQuantity = 3;
			SkuBQuantity = 5;
			SkuCQuantity = 1;
			SkuDQuantity = 1;

			Calculate();
		}

		private int skuAQuantity;
		private int skuBQuantity;
		private int skuCQuantity;
		private int skuDQuantity;
		private int result;
		private readonly Engine engine;
	}
}
