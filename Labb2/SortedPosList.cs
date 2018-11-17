using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Labb2
{
    public class SortedPosList
    {
        private readonly string filePath;
        public bool syncedToFile;

        private List<Position> sortedPosList;
        public static List<SortedPosList> syncedInstances = new List<SortedPosList>();

        public List<Position> SortedList
        {
            get { return sortedPosList; }
            set { sortedPosList = value; }
        }

        public SortedPosList()
        {
            sortedPosList = new List<Position>();
            syncedToFile = false;
        }

        public SortedPosList(string fileName)
        {
            sortedPosList = new List<Position>();
            filePath = Directory.GetCurrentDirectory() + "/" + fileName;
            syncedInstances.Add(this);
            syncedToFile = true;
            if (File.Exists(filePath))
            {
                LoadFromFile();
            }
            else
            {
                CreateFile();
            }
        }

        private void LoadFromFile()
        {
            Console.WriteLine("File already created");
            string[] listFromFile = File.ReadAllLines(filePath);
            sortedPosList.Clear();
            foreach (string pos in listFromFile)
            {

                Add(ParseToPosition(pos));
            }
        }

        public void Add(Position position)
        {
            sortedPosList.Add(position);
            sortedPosList.Sort((pos1, pos2) => pos1.Length().CompareTo(pos2.Length()));
            if(syncedToFile)
            {
                SaveToFile();
            }
        }

        private Position ParseToPosition(string pos)
        {
            char[] charsToRemove = { '(', ')' };
            string trimedPosition = pos.Trim(charsToRemove);
            string[] stringPos = trimedPosition.Split(',');
            Position parsedPosition = new Position(double.Parse(stringPos[0]), double.Parse(stringPos[1]));
            return parsedPosition;
        }

        private void CreateFile()
        {
            using (FileStream fs = File.Create(filePath))
            {
                Console.WriteLine("Created file at path: {0}", filePath);
            }
        }

        private void SaveToFile()
        {
            string[] positions = new string[sortedPosList.Count];
            for (int i = 0; i < sortedPosList.Count; i++)
            {
                positions[i] = sortedPosList[i].ToString();
            }
            File.WriteAllLines(this.filePath, positions);
            foreach(SortedPosList synced in syncedInstances)
            {
                synced.sortedPosList = sortedPosList;
            }
        }

        public int Count()
        {
            return sortedPosList.Count;
        }


        public bool Remove(Position pos)
        {
            bool removed = false;
            if (sortedPosList.Exists(position => position.Equals(pos)))
            {
                Console.WriteLine("to be deleted : {0}", pos);
                sortedPosList.RemoveAll(position => position.Equals(pos));
                removed = true;
            }
            if(syncedToFile)
            {
                SaveToFile();
            }
            return removed;
        }

        public SortedPosList Clone()
        {
            SortedPosList clonedObject = new SortedPosList();

            clonedObject.sortedPosList = new List<Position>();

            foreach(Position position in sortedPosList)
            {
                clonedObject.sortedPosList.Add(position.Clone());
            }

            return clonedObject;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList withinCircleList = new SortedPosList();
            foreach (Position p in sortedPosList)
            {
                if ((Math.Pow(p.X - centerPos.X, 2) + (Math.Pow(p.Y - centerPos.Y, 2))) < Math.Pow(radius, 2))
                {
                    withinCircleList.Add(p.Clone());
                }
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
