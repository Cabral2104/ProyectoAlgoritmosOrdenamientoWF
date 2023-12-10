using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class MezclaNatural
    {
        private List<int> array;

        public MezclaNatural()
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

        // Método para ordenar sin mostrar pasos intermedios
        public void Sort()
        {
            int n = array.Count;
            MezclaNaturalSort(0, n - 1);
        }

        private void MezclaNaturalSort(int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                MezclaNaturalSort(start, middle);
                MezclaNaturalSort(middle + 1, end);

                Merge(start, middle, end);
            }
        }

        private void Merge(int start, int middle, int end)
        {
            List<int> temp = new List<int>();

            int i = start;
            int j = middle + 1;

            // Fusiona las dos secuencias ordenadas
            while (i <= middle && j <= end)
            {
                if (array[i] <= array[j])
                {
                    temp.Add(array[i]);
                    i++;
                }
                else
                {
                    temp.Add(array[j]);
                    j++;
                }
            }

            // Agrega los elementos restantes de la primera secuencia
            while (i <= middle)
            {
                temp.Add(array[i]);
                i++;
            }

            // Agrega los elementos restantes de la segunda secuencia
            while (j <= end)
            {
                temp.Add(array[j]);
                j++;
            }

            // Copia los elementos fusionados de nuevo al array original
            for (int k = 0; k < temp.Count; k++)
            {
                array[start + k] = temp[k];
            }
        }

    }
}
