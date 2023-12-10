using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class GnomeSort
    {
        private List<int> array;

        public GnomeSort()
        {
            array = new List<int>();
        }

        public void InsertValue(int value)
        {
            array.Add(value);
        }

        public List<int> GetArray()
        {
            return new List<int>(array);
        }

        public List<List<int>> SortStepByStep()
        {
            List<List<int>> steps = new List<List<int>>();

            int n = array.Count;
            int index = 0;

            while (index < n)
            {
                if (index == 0)
                {
                    index++;
                }

                if (array[index] >= array[index - 1])
                {
                    index++;
                }
                else
                {
                    // Intercambiar si el elemento actual es menor que el anterior
                    int temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;

                    index--;

                    steps.Add(new List<int>(array));
                }
            }

            return steps;
        }
    }
}
