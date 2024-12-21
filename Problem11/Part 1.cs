using AOC2024.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Problem11
{
    internal class Part_1
    {
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem11\\Input.txt");
        string line;
        int blinkNum;
        List<long> sequence = new List<long>();
        public Part_1()
        {
            blinkNum = 75;
        }

        public void run()
        {
            line = sr.ReadLine();
            sequence = line
            .Split(' ')
            .Select(long.Parse)
            .ToList();

            blink();

            Console.WriteLine("test");
        }

        private void blink()
        {
            //Debug();
            for (int i = 0; i < blinkNum; i++)
            {
                Console.WriteLine(sequence.Count);
                for (int j = sequence.Count - 1; j >= 0; j--)
                {
                    if (FirstRule(j)) continue;
                    else if (SecondRule(j)) continue;
                    else { ThirdRule(j); }
                }
                
                
            }
        }

        private bool FirstRule(int index)
        {
            if (sequence[index] == 0)
            {
                sequence[index] = 1;
                return true;
            }
            return false;
        }

        private bool SecondRule(int index)
        {
            if (sequence[index].ToString().Length % 2 == 0)
            {
                long LValue = 0;
                string line = sequence[index].ToString();

                LValue = long.Parse(line.Substring(0, line.Length / 2));
                long RValue = int.Parse(line.Substring(line.Length / 2, line.Length / 2));
                sequence[index] = LValue;
                sequence.Insert(index + 1, RValue);
                return true;
            }
            return false;
        }

        private void ThirdRule(int index)
        {
            sequence[index] = sequence[index] * 2024;
        }

        private void Debug()
        {
            foreach (var item in sequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
