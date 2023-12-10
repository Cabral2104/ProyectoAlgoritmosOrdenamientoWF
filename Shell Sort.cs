using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class Shell_Sort
    {
        private List<int> array;

        public Shell_Sort()
        {
            array = new List<int>();
        }

        public void InsertValues(int[] values)
        {
            array.Clear();
            array.AddRange(values);
        }

        public void DeleteValue(int value)
        {
            array.Remove(value);
        }

        public List<int> GetArray()
        {
            return array.ToList();
        }
        public void Ordenar()
        {
            int n = array.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = array[i];

                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    array[j] = temp;
                }
            }
        }

        public List<List<int>> SortStepByStep()
        {
            List<List<int>> steps = new List<List<int>>();
            steps.Add(array.ToList()); // Agrega la lista original como el primer paso

            int n = array.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = array[i];

                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    array[j] = temp;
                    steps.Add(array.ToList()); // Agrega la lista después de cada iteración
                }
            }

            return steps;
        }

    }
}
