using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.QuallityManagers
{
    public class StandardQuallityManager : IQualityManager
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.SellIn >= 0)
                {
                    item.Quality = item.Quality - 1;
                }
                else
                {
                    item.Quality = item.Quality - 2;
                }
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
