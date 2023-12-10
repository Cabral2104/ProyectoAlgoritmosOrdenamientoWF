using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class SelectionSort
    {
        private List<int> array;

        public SelectionSort()
        {
            array = new List<int>();
        }

        public void InsertValues(int[] values)
        {
            array.Clear();
            array.AddRange(values);
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
            return array.ToList();
        }

        public List<string> SortStepByStep()
        {
            List<string> steps = new List<string>();
            steps.Add(string.Join(", ", array)); // Agrega la lista original como el primer paso

            int n = array.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Intercambiar elementos
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;

                steps.Add(string.Join(", ", array)); // Agrega la lista después de cada iteración
            }

            return steps;
        }
    }
}
