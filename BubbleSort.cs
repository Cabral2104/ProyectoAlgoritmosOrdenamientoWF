using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class BubbleSort
    {
        private List<int> array;

        public BubbleSort()
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
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Intercambiar array[j] y array[j+1]
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        steps.Add(array.ToList()); // Agrega la lista después de cada intercambio
                    }
                }
            }

            return steps;
        }
    }
}
