﻿using AOC2024.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Problem10
{
    internal class Part_1
    {
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem10\\Input.txt");
        List<List<int>> map;
        List<Point> startPoints;
        string line;
        int total;
        int height;
        int width;
        public Part_1()
        {
            map = new List<List<int>>();
            startPoints = new List<Point>();
            total = 0;
        }

        public void run()
        {
            line = sr.ReadLine();

            while (line != null)
            {
                map.Add(line
                .Select(c => c - '0')
                .ToList());
                line = sr.ReadLine();
            }
            width = map[0].Count; height = map.Count;

            FindStartPoints();

            StartBFSSearch();

            Console.WriteLine("test");
        }

        private void FindStartPoints()
        {
            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[0].Count; x++)
                {
                    if (map[y][x] == 0) startPoints.Add(new Point(y, x));
                }
            }
        }

        private void StartBFSSearch()
        {
            Queue<Point> queue = new Queue<Point>();

            for (int i = 0; i < startPoints.Count; i++)
            {
                HashSet<Point> set = new HashSet<Point>();
                queue.Enqueue(startPoints[i]);

                while(queue.Count > 0) 
                { 
                    var node = queue.Dequeue();
                    
                    foreach (var item in findNeightbors(node))
                    {
                        
                        if(map[node.y][node.x] == 9 && !set.Contains(node))
                        {
                            total++;
                            set.Add(node);
                        }
                        if (map[item.y][item.x] == map[node.y][node.x] + 1)
                        {
                            if (!set.Contains(new Point(item.y, item.x)))
                                queue.Enqueue(item);

                        }
                    }
                }

                //Debug(set);
            }
        }



        private List<Point> findNeightbors(Point position)
        {
            List<Point> result = new List<Point>();
            foreach (var item in Tools.Tools.LinearDirections)
            {
                if(Tools.Tools.CheckOoB(position, item, height, width))
                {
                    result.Add(position + item);
                }
            }
            return result;
        }

            

        private void Debug(HashSet<Point> hash)
        {
            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[0].Count; x++)
                {
                    Console.Write(map[y][x]);
                }
                Console.WriteLine();
            }

            
            char[,] hashmap = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    hashmap[i,j] = '.';
                }
            }

            foreach (var item in hash)
            {
                hashmap[item.y, item.x] = 'X';
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(hashmap[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
