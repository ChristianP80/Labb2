using System;

namespace Labb2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Position one = new Position(3, 3);

            //Position two = one.Clone();

            //Position three = new Position(4, 4);

            //Position four = one + three;

            //Position five = three - one;

            //double distanceBetween = one % three;

            //bool larger = three > one;
            //bool smaller = three < one;

            //SortedPosList sorted = new SortedPosList();
            //sorted.Add(three);
            //sorted.Add(one);
            //sorted.Add(four);
            //sorted.Add(four);

            //Console.WriteLine("Testing Length() : " + one.Length());
            //Console.WriteLine("Testing Equals() : " + one.Equals(three));
            //Console.WriteLine("Testing Clone() samt ToString() : " + two);
            //Console.WriteLine("Testing operator > : " + larger);
            //Console.WriteLine("Testing operator < : " + smaller);
            //Console.WriteLine("Testing operator + : " + four);
            //Console.WriteLine("Testing operator - : " + five);
            //Console.WriteLine("Testing operator % : " + distanceBetween);
            //Console.WriteLine("Testing Count() on sortedPosList : " + sorted.SortedList.Count);

            //for (int i = 0; i < sorted.SortedList.Count; i++)
            //{
            //    Console.WriteLine("Testing sorting on SortedPosList, Pos {0} contains {1}", i, sorted.SortedList[i]);
            //}

            //Console.WriteLine("Testing Remove() on sortedPosList : " + sorted.Remove(four));
            //Console.WriteLine("Testing Remove() on sortedPosList : " + sorted.Remove(two));

            //foreach (var pos in sorted.SortedList)
            //{
            //    Console.WriteLine("After Remove() on SortedPosList, it contains {0}", pos);
            //}

            //SortedPosList sortedCopy = sorted.Clone();
            //Console.WriteLine("Testing Clone() on SortedPosList");
            //foreach(Position position in sortedCopy.SortedList)
            //{
            //    Console.WriteLine("Position in clone : " + position);
            //}

            //SortedPosList withinRadius = sorted.CircleContent(new Position(5, 5), 4);
            //foreach (Position position in withinRadius.SortedList)
            //{
            //    Console.WriteLine("Positions inside circle : " + position);
            //}

            //Console.WriteLine("Testing getter on position: " + sorted.SortedList[1]);

            //Console.WriteLine("Sorted contains: " + sorted);
            //Console.WriteLine("SortedCopy contains: " + sortedCopy);

            //sortedCopy.Add(five);

            //Console.WriteLine("Testing operator - on lists: " + (sortedCopy - sorted));

            //Console.WriteLine("Sorted contains: " + sorted);
            //Console.WriteLine("SortedCopy contains: " + sortedCopy);

            //Console.ReadLine();


            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            Console.WriteLine(list1.Remove(new Position(2, 6)));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");
        }
    }
}


