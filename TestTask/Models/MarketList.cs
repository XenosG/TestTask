using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class MarketList
    {
        private readonly List<Market> _markets;

        public MarketList()
        {
            _markets = new List<Market>();
        }
    }
}
