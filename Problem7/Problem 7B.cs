using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Problem7
{
    public class Problem_7B
    {
        string line;
        long total;
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem7\\Input.txt");
        public Problem_7B() { }
        public void run()
        {
            line = sr.ReadLine();

            while (line != null)
            {
                total += SolveEq(ParseText(line));
                line = sr.ReadLine();
            }

            Console.WriteLine(total);
        }

        public long[] ParseText(string line)
        {
            List<int> result = new List<int>();
            string[] splitstring = line.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long[] numbers = Array.ConvertAll(splitstring, long.Parse);
            return numbers;
        }

        public long SolveEq(long[] list)
        {
            long wanted = list[0];

            if (solve(list, 1, wanted, list[1]))
            {
                return wanted;
            }
            return 0;
        }

        public bool solve(long[] list, int step, long goal, long sum)
        {
            if (step + 1 == list.Length && sum == goal) return true;
            else if (step + 1 == list.Length) return false;

            if (solve(list, step + 1, goal, sum + list[step + 1])) return true;
            if (solve(list, step + 1, goal, combine(sum, list[step + 1]))) return true;
            if (solve(list, step + 1, goal, sum * list[step + 1])) return true;

            return false;
        }

        public long combine(long a, long b)
        {
            string combined = a.ToString() + b.ToString();
            return long.Parse(combined);
        }
    }

}
