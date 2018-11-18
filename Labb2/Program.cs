using System;

namespace Labb2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Skapar upp lite possitioner för att lägga in i listor
            Position one = new Position(3, 3);
            Position two = one.Clone();
            Position three = new Position(4, 4);
            Position four = one + three;
            Position five = three - one;
            Position six = new Position(10, 10);

            //Tester av operatorer
            double distanceBetween = one % three;
            bool larger = three > one;
            bool larger2 = one > three;
            bool smaller = three < one;
            bool smaller2 = one < three;

            //Lägger in possitioner i en SortedPosList
            SortedPosList sorted = new SortedPosList();
            sorted.Add(three);
            sorted.Add(one);
            sorted.Add(four);
            sorted.Add(five);

            //Utskrifter av resultat på operatorer samt metoder
            Console.WriteLine("Förväntar mig avståndet från origo till given position {0}", one );
            Console.WriteLine("Testing Length() : {0} \n", one.Length());

            Console.WriteLine("Förväntar mig false, (3, 3) är inte lika med (4, 4)");
            Console.WriteLine("Testing Equals() : {0} \n", one.Equals(three));

            Console.WriteLine("Förvänar mig (3, 3) då jag klonat position one som är (3, 3)");
            Console.WriteLine("Testing Clone() samt ToString() : {0} \n", two);

            Console.WriteLine("Förväntar mig true, (4, 4) är större än (3, 3)");
            Console.WriteLine("Testing operator > : {0} \n", larger);

            Console.WriteLine("Förväntar mig false, (3, 3) är INTE större än (4, 4)");
            Console.WriteLine("Testing operator > : {0} \n", larger2);

            Console.WriteLine("förväntar mig false, (4, 4) är inte mindre än (3, 3)");
            Console.WriteLine("Testing operator < : {0} \n", smaller);

            Console.WriteLine("förväntar mig true, (3, 3) är mindre än (4, 4)");
            Console.WriteLine("Testing operator < : {0} \n", smaller2);

            Console.WriteLine("förväntar mig (7, 7) då (3, 3) + (4, 4) blir det");
            Console.WriteLine("Testing operator + : {0} \n", four);

            Console.WriteLine("förväntar mig (1, 1) då (4, 4) - (3, 3) blir det");
            Console.WriteLine("Testing operator - : {0} \n", five);

            Console.WriteLine("förväntar mig avståndet mellan (3, 3) och (4, 4)");
            Console.WriteLine("Testing operator % : {0} \n", distanceBetween);

            Console.WriteLine("förväntar mig 4 då jag lagt till 4 positioner");
            Console.WriteLine("Testing Count() on sortedPosList : {0} \n", sorted.SortedList.Count);

            //Loopar igenom en lista av positioner, ska skrivas ut sorterad
            Console.WriteLine("Förväntar mig en sorterad lista på fyra positioner");
            for (int i = 0; i < sorted.SortedList.Count; i++)
            {
                Console.WriteLine("Testing sorting on SortedPosList, Pos {0} contains {1}", i, sorted.SortedList[i]);
            }
            Console.WriteLine();

            // Testar Remove metoden på en lista, skriver även ut listan efter för att säkertställa att den tagit bort possitionerna
            Console.WriteLine("Förväntar mig true, true, false samt att listan är två mindre då jag kör Remove() på två positioner");
            Console.WriteLine("Testing Remove() on sortedPosList : {0}", sorted.Remove(four));
            Console.WriteLine("Testing Remove() on sortedPosList : " + sorted.Remove(two));
            Console.WriteLine("Testing Remove() on sortedPosList : {0}", sorted.Remove(six));
            foreach (var pos in sorted.SortedList)
            {
                Console.WriteLine("After Remove() on SortedPosList, it contains {0}", pos);
            }
            Console.WriteLine();

            //Testar att klona en lista och skriver ut den sedan
            SortedPosList sortedCopy = sorted.Clone();
            Console.WriteLine("Testing Clone() on SortedPosList");
            foreach(Position position in sortedCopy.SortedList)
            {
                Console.WriteLine("Position in clone : " + position);
            }
            Console.WriteLine();

            //Test för att kolla om det finns nån cirkel innanför given cirkels pos och radie
            Console.WriteLine("Förväntar mig två punkter innan för given cirekl med given radie (1, 1) radie 5");
            SortedPosList withinRadius = sorted.CircleContent(new Position(1, 1), 5);
            foreach (Position position in withinRadius.SortedList)
            {
                Console.WriteLine("Positions inside circle : " + position);
            }
            Console.WriteLine();

            //Skapar upp en ny lista för att kunna testa + operator på listor
            SortedPosList toAdd = new SortedPosList();
            toAdd.Add(new Position(1, 1));
            toAdd.Add(new Position(8, 8));
            toAdd.Add(new Position(11, 11));
            toAdd.Add(new Position(3, 3));

            //Test av + operator på listor
            SortedPosList addingLists = sorted + toAdd;
            Console.WriteLine("Förväntar mig en ny sammanslagen lista av sorted + toAdd");
            Console.WriteLine("Testing operator + on SortedPosLists : {0}", addingLists);
            Console.WriteLine();

            //Tetsar getter på en lista
            Console.WriteLine("Förväntar mig (4, 4) sorted[1] är det");
            Console.WriteLine("Testing getter on position: " + sorted[1]);
            Console.WriteLine();

            //Testar - operator på listor, lägger först till en ny possition i en av listorna för dom är identiska
            sortedCopy.Add(new Position(20, 20));
            Console.WriteLine("Sorted contains: " + sorted);
            Console.WriteLine("SortedCopy contains: " + sortedCopy);
            Console.WriteLine("Förväntar mig en position (20, 20)");
            Console.WriteLine("Testing operator - on lists: " + (sortedCopy - sorted));

            //Test av att skriva till fil, skapar först upp en konstant som är filnamnet den ska skapa om den inte redan finns
            //sen skapar jag upp två nya SortedPosLists för att kolla allt funkar
            const string fileName = "writePosToFile.txt";
            Console.WriteLine();
            Console.WriteLine("Färväntar mig att den skapar upp en fil, sen hintar om att fil redan är \n skapad, samt att den sparar ett antal position till fil");
            SortedPosList listFromFile = new SortedPosList(fileName);
            SortedPosList testLoad2 = new SortedPosList(fileName);

            //Lägger tilllite possitioner för att se så dom skrivs ner till filen
            listFromFile.Add(new Position(10, 10));
            listFromFile.Add(new Position(1, 1));
            listFromFile.Add(new Position(2, 2));
            listFromFile.Add(new Position(30, 30));
            listFromFile.Add(new Position(5, 5));
            listFromFile.Add(new Position(4, 4));
            listFromFile.Add(new Position(9, 9));
            listFromFile.Add(new Position(5, 5));

            //Testar inläsning från fil, skapar upp en ny SortedPosList som ska läsa in alla possitioner som finns i 
            //filen, och skriver sedan ut den
            Console.WriteLine();
            Console.WriteLine("Förväntar mig 'file already created' och att den nya sortedPosList laddar in alla positioner ifrån filen");
            SortedPosList testLoad3 = new SortedPosList(fileName);
            Console.WriteLine("testload 3 : {0}", testLoad3);
            Console.WriteLine();

            //Test för att kolla så att SortedPosList verkligen är synkade till filen
            Console.WriteLine("Förväntar mig 'file already created fyra gånger då jag skapar fyra nya synkade listor, \n" +
                              "lägger till en ny position (1000, 1000) i en av listorna och loopar igenom för att testa om \n" +
                              "dom verkligen är synkade mot filen");
            SortedPosList synced1 = new SortedPosList(fileName);
            SortedPosList synced2 = new SortedPosList(fileName);
            SortedPosList synced3 = new SortedPosList(fileName);
            SortedPosList synced4 = new SortedPosList(fileName);
            synced4.Add(new Position(1000, 1000));

            foreach(SortedPosList sync in SortedPosList.syncedInstances)
            {
                Console.WriteLine(sync);
            }
        }
    }
}


