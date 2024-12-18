using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOC2024.Tools;

namespace AOC2024.Problem8
{
    internal class Part_1
    {
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem8\\Input.txt");

        public Part_1() { }
        string line;
        int total;
        List<char> uniqueAntena = new List<char>();
        List<List<char>> map = new List<List<char>>();
        Dictionary<char, List<Point>> antenas = new Dictionary<char, List<Point>>();

        public void run()
        {
            line = sr.ReadLine();

            while (line != null)
            {
                map.Add(line.ToList<char>());
                line = sr.ReadLine();
            }


            sortAntena();

            debug();

            runThruAntena();

            debug();

            Console.WriteLine("ye");
        }

        private void runThruAntena()
        {
            for (int i = 0; i < uniqueAntena.Count; i++)
            {
                for (int j = 0; j < antenas[uniqueAntena[i]].Count; j++)
                {
                    for (int k = j + 1; k < antenas[uniqueAntena[i]].Count; k++)
                    {

                        GetCombinedPosition(antenas[uniqueAntena[i]][j], antenas[uniqueAntena[i]][k]);
                    }
                }
            }
        }

        private void GetCombinedPosition(Point a, Point b)
        {
            Point newA = a - (b - a);
            if (CheckOutOfBoundary(newA))
            {
                if (CheckPosition(newA))
                {
                    total++;
                    setNode(newA);
                }
            }


            Point newB = b + (b - a);
            if (CheckOutOfBoundary(newB))
            {
                if (CheckPosition(newB))
                {
                    total++;
                    setNode(newB);
                }
            }
        }

        private void setNode(Point a)
        {
            map[a.y][a.x] = '#';
        }

        private bool CheckOutOfBoundary(Point position)
        {
            if (position.x < 0 || position.y < 0) return false;
            else if (position.x >= map[0].Count || position.y >= map.Count) return false;
            return true;
        }
        private bool CheckPosition(Point position)
        {
            if (map[position.y][position.x] != '#') return true;
            return false;
        }

        private void debug()
        {
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[0].Count; j++)
                {
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void sortAntena()
        {
            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[0].Count; x++)
                {
                    if (map[y][x] != '.')
                        addAntena(map[y][x], new Point(y, x));
                }
            }
        }
        private void addAntena(char key, Point position)
        {
            if (antenas.ContainsKey(key))
            {
                antenas[key].Add(position);
            }
            else
            {
                antenas.Add(key, new List<Point>() { position });
                uniqueAntena.Add(key);
            }
        }
    }
}
