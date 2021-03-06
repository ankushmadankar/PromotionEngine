﻿using PromotionEngine.Interface;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PromotionEngine
{
    public class Engine
    {
        private readonly IEnumerable<IRule> rules;
        
        public Engine(IEnumerable<IRule> rules)
        {
            this.rules = rules;
        }

        public int Execute(IReadOnlyDictionary<Sku, int> skues)
        {
            if (rules == null || !rules.Any())
                return 0;

            int sum = 0;

            foreach (IRule rule in rules)
            {
                sum += rule.Execute(skues);
            }

            return sum;
        }

        /// <summary>
        /// Create test engine with pre-defined values for SKU.
        /// </summary>
        /// <returns></returns>
        public static Engine GetTestEngine()
        {
            MultiplierRule ruleA = new MultiplierRule("A", 3, 130);
            MultiplierRule ruleB = new MultiplierRule("B", 2, 45);
            AlliesRule ruleCD = new AlliesRule("C", "D", 30);

            Engine engine = new Engine(new List<IRule> { ruleA, ruleB, ruleCD });

            return engine;
        }
    }
}
