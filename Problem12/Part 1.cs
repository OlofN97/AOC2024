using AOC2024.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Problem12
{
    internal class Part_1
    {
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem12\\Input.txt");
        string line;
        List<List<Node>> nodes = new List<List<Node>>();
        int height;
        int width;
        int total;


        public Part_1()
        {
            total = 0;

        }

        public void run()
        {
            int x = 0;
            int y = 0;
            line = sr.ReadLine();
            while (line != null)
            {
                List<char> tempList = line.ToCharArray().ToList();
                nodes.Add(new List<Node>());
                foreach (char c in tempList)
                {
                    nodes[nodes.Count - 1].Add(new Node(y, x, c));
                    x++;
                }
                y++;
                line = sr.ReadLine();
            }
            height = nodes.Count; width = nodes[0].Count;

            RunThruField();

            Debug();
            Console.WriteLine(total);
            Console.WriteLine("test");
        }

        private void RunThruField()
        {
            for (int y = 0; y < nodes.Count; y++)
            {
                for (int x = 0; x < nodes[0].Count; x++)
                {
                    if (!nodes[y][x].visited)
                    {
                        SamplePos(new Point(y, x));
                    }
                }
            }
        }

        private void SamplePos(Point pos)
        {
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(pos);
            Point point;
            int edges = 0;
            int plots = 0;
            while (queue.Count > 0)
            {
                point = queue.Dequeue();
                Node tmp = nodes[point.y][point.x];
                tmp.visited = true;
                nodes[point.y][point.x] = tmp; //I dont know why i haft to do this fml

                foreach (var item in Tools.Tools.LinearDirections)
                {
                    if (!Tools.Tools.CheckOoB(point, item, height, width))
                    {
                        edges++;
                        continue;
                    }
                    else if (nodes[point.y][point.x].charValue == nodes[point.y + item.y][point.x + item.x].charValue)
                    {
                        if (!nodes[point.y + item.y][point.x + item.x].visited && !queue.Contains(point + item))
                        {
                            queue.Enqueue(point + item);
                        }
                    }
                    else
                    {
                        edges++;
                    }
                }
                plots++;
            }
            total += CalculateTotal(edges, plots);
        }

       
        private int CalculateTotal(int edges, int plots)
        {
            return edges * plots;
        }



        private void Debug()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[0].Count; j++)
                {
                    Console.Write(nodes[i][j].charValue);
                }
                Console.WriteLine();
            }
        }
    }
}
