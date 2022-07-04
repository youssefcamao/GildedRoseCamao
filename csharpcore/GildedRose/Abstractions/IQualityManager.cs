﻿using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Abstractions
{
    public interface IQualityManager
    {
        void UpdateQuality(Item item);
    }
}
