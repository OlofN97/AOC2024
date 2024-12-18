using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Problem9
{
    public class Part_2
    {
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem9\\Input.txt");
        int[] sequence;
        List<int> dataFile;
        long total;
        public Part_2()
        {
            dataFile = new List<int>();
        }

        public void run()
        {
            string line = sr.ReadLine();
            sequence = line
            .Select(c => c - '0')
            .ToArray();

            CreateDatafile();

            debugSequence();

            debugDataFile();
            SortDatafile();
            debugDataFile();

            CalculateTotal();

            Console.WriteLine(dataFile.ToString());
        }

        private void CalculateTotal()
        {
            for (int i = 0; i < dataFile.Count; i++)
            {
                if (dataFile[i] == -1) break;
                else
                {
                    total += dataFile[i] * i;
                }
            }
        }

        private void SortDatafile()
        {
            int k = dataFile.Count - 1;
            for (int i = 0; i < dataFile.Count; i++)
            {
                if (dataFile[i] != -1) continue;
                if (k <= i) break; //Sorted
                for (; k > 0; k--)
                {
                    if (dataFile[k] == -1) continue;
                    if (k == i) break;
                    SwitchPlaces(i, k);
                    break;
                }
            }
        }

        private void SwitchPlaces(int i, int k)
        {
            int temp = dataFile[k];
            dataFile[k] = dataFile[i];
            dataFile[i] = temp;
        }

        public void CreateDatafile()
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                for (int k = 0; k < sequence[i]; k++)
                {
                    if (i % 2 == 0)
                        dataFile.Add(i / 2);
                    else
                        dataFile.Add(-1);
                }
            }
        }


        private void debugSequence()
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i]);

            }
            Console.WriteLine();

        }
        private void debugDataFile()
        {
            for (int i = 0; i < dataFile.Count; i++)
            {
                if (dataFile[i] == -1)
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write(dataFile[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
