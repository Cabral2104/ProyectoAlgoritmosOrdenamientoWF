using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class QuickSort
    {
        private List<int> array;

        public QuickSort()
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

        public List<List<int>> SortStepByStep()
        {
            List<List<int>> steps = new List<List<int>>();
            QuickSortAlgorithm(0, array.Count - 1, steps);
            return steps;
        }

        private void QuickSortAlgorithm(int low, int high, List<List<int>> steps)
        {
            if (low < high)
            {
                int pi = Partition(low, high, steps);

                // Recursivamente ordenar los elementos antes y después de la partición
                QuickSortAlgorithm(low, pi - 1, steps);
                QuickSortAlgorithm(pi + 1, high, steps);
            }
        }

        private int Partition(int low, int high, List<List<int>> steps)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;

                    // Intercambiar array[i] y array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    steps.Add(array.ToList()); // Agrega una copia de la lista después de cada iteración
                }
            }

            // Intercambiar array[i+1] y array[high] (o el pivote)
            int tempPivot = array[i + 1];
            array[i + 1] = array[high];
            array[high] = tempPivot;

            steps.Add(array.ToList()); // Agrega una copia de la lista después de cada iteración

            return i + 1;
        }
    }
}
