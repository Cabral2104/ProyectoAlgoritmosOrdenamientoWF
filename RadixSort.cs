using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class RadixSort
    {
        public List<List<int>> SortStepByStep(List<int> inputList)
        {
            List<List<int>> steps = new List<List<int>>();

            int maxDigits = GetMaxDigits(inputList);

            for (int digitPlace = 1; digitPlace <= maxDigits; digitPlace++)
            {
                CountingSortByDigit(inputList, digitPlace);

                // Agrega una copia de la lista actual a los pasos
                steps.Add(new List<int>(inputList));
            }

            return steps;
        }

        private void CountingSortByDigit(List<int> inputList, int digitPlace)
        {
            const int baseValue = 10;  // Consideramos números en base 10

            List<int>[] buckets = new List<int>[baseValue];

            for (int i = 0; i < baseValue; i++)
            {
                buckets[i] = new List<int>();
            }

            foreach (int num in inputList)
            {
                int digit = GetDigit(num, digitPlace);
                buckets[digit].Add(num);
            }

            // Concatena los buckets en la lista original
            inputList.Clear();
            foreach (var bucket in buckets)
            {
                inputList.AddRange(bucket);
            }
        }

        private int GetDigit(int number, int digitPlace)
        {
            return (number / (int)Math.Pow(10, digitPlace - 1)) % 10;
        }

        private int GetMaxDigits(List<int> inputList)
        {
            int maxDigits = 0;

            foreach (int num in inputList)
            {
                int numDigits = (int)Math.Floor(Math.Log10(num) + 1);
                maxDigits = Math.Max(maxDigits, numDigits);
            }

            return maxDigits;
        }
    }
}
