using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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

            //debugSequence();

            //debugDataFile();
            SortDatafile();
            //debugDataFile();

            CalculateTotal();

            Console.WriteLine(dataFile.ToString());
        }

        private void CalculateTotal()
        {
            for (int i = 0; i < dataFile.Count; i++)
            {
                if (dataFile[i] == -1) continue;
                else
                {
                    total += dataFile[i] * i;
                }
            }
        }

        private void SortDatafile()
        {

            int i = sequence.Length % 2 == 0 ? sequence.Length - 2 : sequence.Length - 1;
            for (; i >= 0; i -= 2)
            {
                int k = FindEmptySpot(sequence[i], i);
                if (k != -1)
                {
                    swap(k, i, sequence[i]);
                    //debugSequence();

                    //debugDataFile();
                }
            }
        }
        private void swap(int firstIndex, int SecondIndex, int size)
        {
            int dataPos1 = firstIndex;
            int dataPos2 = FindPositionInDatafile(SecondIndex);

            for (int i = 0; i < size; i++)
            {
                SwitchPlaces(dataPos1 + i, dataPos2 + i);
            }
        }

        private int FindPositionInDatafile(int index)
        {
            int pos = 0;
            if (index == 0) return pos;
            else
            {
                for (int i = 0; i < index; i++)
                {
                    pos += sequence[i];
                }
            }
            return pos;
        }

        private int FindEmptySpot(int size, int maxIndex)
        {
            int count = 0;
            int max = SequenceToData(maxIndex);
            for (int i = 0; i < max; i++)
            {
                if (dataFile[i] == -1)
                {
                    count++;
                    if (count == size) return i - count + 1;
                }
                else if (dataFile[i] != -1)
                {
                    count = 0;
                }
            }
            return -1;
        }

        private int SequenceToData(int index)
        {
            int pos = 0;
            for (int i = 0; i < index; i++)
            {
                pos += sequence[i];
            }
            return pos;
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
            Console.WriteLine();

            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i]);

            }
            Console.WriteLine();

        }
        private void debugDataFile()
        {
            Console.WriteLine();

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
