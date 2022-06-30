using GildedRose.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private IList<Item> _items;
        private readonly Dictionary<string, Func<Item, IQualityManager>> _qualityItemsDefinition;
        public GildedRose(IList<Item> Items, Dictionary<string, Func<Item, IQualityManager>> qualityItemsDefinition)
        {
            _items = Items;
            _qualityItemsDefinition = qualityItemsDefinition;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (_qualityItemsDefinition.TryGetValue(item.Name, out var getQualityFunc))
                {
                    var qualityManager = getQualityFunc.Invoke(item);
                    qualityManager.UpdateQuality();
                }
            }
        }
    }
}
