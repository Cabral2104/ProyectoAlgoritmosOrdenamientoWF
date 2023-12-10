using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class HeapSort
    {
        private List<int> array;

        public HeapSort()
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
            steps.Add(array.ToList()); // Agrega la lista original como el primer paso

            int n = array.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n, i, steps);
            }

            for (int i = n - 1; i > 0; i--)
            {
                // Intercambiar el elemento actual con el primero de la heap
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                steps.Add(array.ToList()); // Agrega la lista después de cada iteración

                // Llamar a Heapify en la heap reducida
                Heapify(i, 0, steps);
            }

            return steps;
        }

        private void Heapify(int n, int i, List<List<int>> steps)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                // Intercambiar el elemento actual con el más grande encontrado
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                steps.Add(array.ToList()); // Agrega la lista después de cada iteración

                // Llamar a Heapify en la sub-heap afectada
                Heapify(n, largest, steps);
            }
        }
    }
}
