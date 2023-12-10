using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class CountingSort
    {
        private List<int> array;

        public CountingSort()
        {
            array = new List<int>();
        }

        public void InsertValue(int value)
        {
            array.Add(value);
        }

        public void DeleteValue(int value)
        {
            array.Remove(value);
        }

        public List<int> GetArray()
        {
            return new List<int>(array);
        }

        public List<List<int>> SortStepByStep()
        {
            List<List<int>> steps = new List<List<int>>();

            // Implementación del algoritmo Counting Sort
            int max = array.Max();
            int min = array.Min();
            int range = max - min + 1;

            int[] countingArray = new int[range];
            List<int> sortedArray = new List<int>();

            foreach (var value in array)
            {
                countingArray[value - min]++;
                steps.Add(new List<int>(countingArray));
            }

            for (int i = min; i <= max; i++)
            {
                while (countingArray[i - min] > 0)
                {
                    sortedArray.Add(i);
                    countingArray[i - min]--;
                    steps.Add(new List<int>(sortedArray));
                }
            }

            return steps;
        }
    }
}
