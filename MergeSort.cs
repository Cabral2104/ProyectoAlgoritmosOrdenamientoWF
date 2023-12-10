using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class MergeSort
    {
        private List<int> array;

        public MergeSort()
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
            MergeSortAlgorithm(0, array.Count - 1, steps);
            return steps;
        }

        private void MergeSortAlgorithm(int low, int high, List<List<int>> steps)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;

                MergeSortAlgorithm(low, middle, steps);
                MergeSortAlgorithm(middle + 1, high, steps);

                Merge(low, middle, high, steps);
            }
        }

        private void Merge(int low, int middle, int high, List<List<int>> steps)
        {
            int n1 = middle - low + 1;
            int n2 = high - middle;

            List<int> left = new List<int>(n1);
            List<int> right = new List<int>(n2);

            int i, j;

            for (i = 0; i < n1; ++i)
                left.Add(array[low + i]);

            for (j = 0; j < n2; ++j)
                right.Add(array[middle + 1 + j]);

            i = 0;
            j = 0;
            int k = low;

            while (i < n1 && j < n2)
            {
                if (left[i] <= right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;

                // Agrega una copia actualizada de la lista al paso
                steps.Add(new List<int>(array));
            }

            while (i < n1)
            {
                array[k] = left[i];
                i++;
                k++;

                // Agrega una copia actualizada de la lista al paso
                steps.Add(new List<int>(array));
            }

            while (j < n2)
            {
                array[k] = right[j];
                j++;
                k++;

                // Agrega una copia actualizada de la lista al paso
                steps.Add(new List<int>(array));
            }
        }
    }
}
