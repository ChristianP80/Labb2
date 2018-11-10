using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    public class SortedPosList
    {
        List<Position> sortedPosList = new List<Position>();

        public SortedPosList()
        {
        }

        public int Count()
        {
            return sortedPosList.Count;
        }

        public void Add(Position position)
        {
            sortedPosList.Add(position);

            List<Position> tempList = sortedPosList;
            tempList.OrderBy(o => o.X);

            //List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();
        }
    }
}
