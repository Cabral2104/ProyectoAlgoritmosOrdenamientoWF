using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class CocktailSort
    {
        private List<int> array;

        public CocktailSort()
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
            int n = array.Count;
            bool swapped = true;
            int start = 0;
            int end = n - 1;

            while (swapped)
            {
                // forward pass
                swapped = false;
                for (int i = start; i < end; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(i, i + 1);
                        swapped = true;
                        steps.Add(new List<int>(array));
                    }
                }

                if (!swapped)
                    break;

                // backward pass
                swapped = false;
                end--;

                for (int i = end - 1; i >= start; --i)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(i, i + 1);
                        swapped = true;
                        steps.Add(new List<int>(array));
                    }
                }

                start++;
            }

            return steps;
        }

        private void Swap(int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
