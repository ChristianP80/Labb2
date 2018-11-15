using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    public class SortedPosList
    {
        private string filePath;

        public string Filepath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private List<Position> sortedPosList;

        public List<Position> SortedList
        {
            get { return sortedPosList; }
            set { sortedPosList = value; }
        }

        public SortedPosList() { sortedPosList = new List<Position>(); }

        public SortedPosList(string filePath)
        {
            sortedPosList = new List<Position>();
            this.filePath = filePath;
            Load();

        }

        private void Load()
        {
            if(!System.IO.File.Exists(filePath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", filePath);
                return;
            }
        }

        public int Count()
        {
            return sortedPosList.Count;
        }

        public void Add(Position position)
        {
            sortedPosList.Add(position);
            sortedPosList.Sort((pos1, pos2) => pos1.Length().CompareTo(pos2.Length()));
        }

        public bool Remove(Position pos)
        {
            bool removed = false;
            if (sortedPosList.Exists(position => position.Equals(pos)))
            {
                sortedPosList.RemoveAll(position => position.Equals(pos));
                removed = true;
            }
            return removed;
        }

        public SortedPosList Clone()
        {
            SortedPosList clonedObject = new SortedPosList();

            clonedObject.sortedPosList = new List<Position>();

            foreach(Position position in sortedPosList)
            {
                clonedObject.sortedPosList.Add(position);
            }

            return clonedObject;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList withinCircleList = new SortedPosList();
            foreach (Position p in sortedPosList)
            {
                if (p % centerPos <= radius)
                    withinCircleList.Add(p);
            }
            return withinCircleList;
        }

        public static SortedPosList operator +(SortedPosList a, SortedPosList b)
        {
            SortedPosList result = new SortedPosList();
            foreach (Position position in a.sortedPosList)
                result.Add(position);
            foreach (Position position in b.sortedPosList)
                result.Add(position);
            return result;
        }

        public Position this[int key] => sortedPosList[key];

        public override string ToString() => string.Join(", ", sortedPosList);

        public static SortedPosList operator -(SortedPosList a, SortedPosList b)
        {
            int clonedIndex = 0;
            int bIndex = 0;
            SortedPosList clonedList = a.Clone();

            while (clonedIndex < clonedList.Count() && bIndex < b.Count())
            {
                if (clonedList[clonedIndex].Equals(b[bIndex]))
                {
                    clonedList.Remove(clonedList[clonedIndex]);
                }
                else
                {
                    if (clonedList[clonedIndex].Length() >= b[bIndex].Length()) bIndex++;
                    else clonedIndex++;
                }
            }
            return clonedList;


        }
    }
}
