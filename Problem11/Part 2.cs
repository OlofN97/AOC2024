using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Problem11
{
    internal class Part_2
    {
        StreamReader sr = new StreamReader("C:\\Users\\olof_\\OneDrive\\Skrivbord\\AOC2024\\AOC2024\\Problem11\\Input.txt");
        string line;
        int blinkNum;
        List<long> sequence = new List<long>();
        Dictionary<long, long> sequnceDic = new Dictionary<long, long>();
        Dictionary<long, List<long>> keyValuePairs = new Dictionary<long, List<long>>();
        Dictionary<long, long> tempValues = new Dictionary<long, long>();
        public Part_2()
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
            foreach (var item in sequence)
            {
                if (sequnceDic.ContainsKey(item))
                {
                    sequnceDic[item]++;
                }
                else
                {
                    sequnceDic.Add(item, 1);
                }
            }

            for (int i = 0; i < blinkNum; i++)
            {
                //Console.WriteLine(i);
                //Debug();
                blink();
                //Debug();
                DebugAmountInList();
                
                    

            }
            //
            //Console.WriteLine(DebugDicitonary());
            DebugAmountInList();

        }

        private void DebugAmountInList()
        {
            long total = 0;
            foreach (var item in sequnceDic.Values)
            {
                total += item;
            }
            Console.WriteLine(total);
        }

       

        private int DebugDicitonary()
        {
            int total = 0;
            foreach (var item in sequence)
            {
                if (!keyValuePairs.ContainsKey(item))
                {
                    total++;
                }
            }
            return total;
        }

        public void blink()
        {
            var keys = sequnceDic.Keys.ToList();
            foreach (var item in keys)
            {
                if (sequnceDic[item] == 0) continue;
                UpdateSequence(item, sequnceDic[item]);
            }
            foreach (var item in tempValues.Keys)
            {
                if (sequnceDic.ContainsKey(item))
                sequnceDic[item] = tempValues[item];
                else
                {
                    sequnceDic.Add(item, tempValues[item]);
                }
            }
            tempValues.Clear();
        }

        public void UpdateSequence(long key, long value)
        {
            sequnceDic[key] = 0;
            if (keyValuePairs.ContainsKey(key))
            {
                AddValuesToSequence(key, value);
                RemoveValuesFromSequence(key);
            }
            else
            {
                UpdateKeyValuePairs(key);
                AddValuesToSequence(key, value);
                RemoveValuesFromSequence(key);
            }


            //long key = sequence[index];
            //if (keyValuePairs[key].Count == 2)
            //{
            //    sequence[index] = (keyValuePairs[key][0]);
            //    sequence.Add(keyValuePairs[key][1]);
            //}
            //else
            //{
            //    sequence[index] = (keyValuePairs[key][0]);
            //}
        }

        public void AddValuesToSequence(long key, long value)
        {
            foreach (var item in keyValuePairs[key])
            {
                if (tempValues.ContainsKey(item))
                {
                    tempValues[item] += value;
                }
                else
                {
                    tempValues.Add(item, value);
                }               
            }       
        }

        public void RemoveValuesFromSequence(long key) 
        {
            if (sequnceDic.ContainsKey(key))
            {
                sequnceDic[key] = 0;
            }
            else if (tempValues.ContainsKey(key))
            {
                tempValues[key] = 0;
            }
            else
            {
                tempValues.Add(key, 0);
            }

        }


        public void UpdateKeyValuePairs(long key)
        {            
            if (FirstRule(key)) keyValuePairs.Add(key, new List<long> { 1 });
            else if (TrySecondRule(key)) keyValuePairs.Add(key, SecondRule(key));
            else
            {
                keyValuePairs.Add(key, new List<long> { ThirdRule(key) });
            }
        }

        private bool FirstRule(long key)
        {
            if (key == 0)
            {
                return true;
            }
            return false;
        }

        private bool TrySecondRule(long key)
        {
            return key.ToString().Length % 2 == 0 ? true : false;
        }

        private List<long> SecondRule(long key)
        {

            long LValue;
            string line = key.ToString();

            LValue = long.Parse(line.Substring(0, line.Length / 2));
            long RValue = int.Parse(line.Substring(line.Length / 2, line.Length / 2));
            List<long> result = new List<long> { LValue, RValue };

            return result;
        }

        private long ThirdRule(long key)
        {
            return key * 2024;
        }

        private void Debug()
        {
            foreach (var item in sequnceDic.Keys)
            {
                for (int i = 0; i < sequnceDic[item]; i++)
                {
                    if (sequnceDic[item] == 0) continue;
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
