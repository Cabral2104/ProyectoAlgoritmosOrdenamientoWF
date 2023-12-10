using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public partial class Form1 : Form
    {
        private Shell_Sort shellSort;
        private List<int> valoresIngresados;
        private SelectionSort selectionSort;
        private List<int> valoresIngresadosSelectionSort;
        private HeapSort heapSort;
        private List<int> valoresIngresadosHeapSort;
        private QuickSort quickSort;
        private List<int> valoresIngresadosQuickSort;
        private BubbleSort bubbleSort;
        private CocktailSort cocktailSort;
        private InsertionSort insertionSort;
        private CountingSort countingSort;
        private MergeSort mergeSort = new MergeSort();
        private BinaryTreeSort binaryTreeSort = new BinaryTreeSort();
        private RadixSort radixSort = new RadixSort();
        private List<int> numbersToSort = new List<int>();
        private List<List<int>> sortingSteps = new List<List<int>>();
        private GnomeSort gnomeSort = new GnomeSort();
        private MezclaNatural mezclaNatural = new MezclaNatural();
        

        public Form1()
        {
            InitializeComponent();
            shellSort = new Shell_Sort();
            valoresIngresados = new List<int>();
            selectionSort = new SelectionSort();
            valoresIngresadosSelectionSort = new List<int>();
            heapSort = new HeapSort();
            valoresIngresadosHeapSort = new List<int>();
            quickSort = new QuickSort();
            valoresIngresadosQuickSort = new List<int>();
            bubbleSort = new BubbleSort();
            cocktailSort = new CocktailSort();
            insertionSort = new InsertionSort();
            countingSort = new CountingSort();
            mergeSort = new MergeSort();
            binaryTreeSort = new BinaryTreeSort();
            radixSort = new RadixSort();
            numbersToSort = new List<int>();
            sortingSteps = new List<List<int>>();
            gnomeSort = new GnomeSort();
            mezclaNatural = new MezclaNatural();
            
        }

        //SHELL SORT
       
        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
           
            if (int.TryParse(txtValorAInsertar.Text, out int valor))
            {
                valoresIngresados.Add(valor);
                MostrarListaEnListBox(lstAntesOrdenar, valoresIngresados);
                txtValorAInsertar.Clear();  // Limpiar el cuadro de texto después de insertar
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAEliminar.Text, out int valor))
            {
                shellSort.DeleteValue(valor);
                MostrarListaEnListBox(lstAntesOrdenar, shellSort.GetArray());
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrdenarShellSort_Click_1(object sender, EventArgs e)
        {
            // Insertar todos los valores en la instancia de ShellSort y luego obtener los pasos de ordenamiento
            shellSort.InsertValues(valoresIngresados.ToArray());
            var steps = shellSort.SortStepByStep();

            foreach (var step in steps)
            {
                MostrarListaEnListBox(lstDespuesOrdenar, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500); 
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenar.Items.Clear();
            lstDespuesOrdenar.Items.Clear();
        }
       
        // Método auxiliar para mostrar la lista en un ListBox
        private void MostrarListaEnListBox(ListBox listBox, List<int> lista)
        {
            
            listBox.Items.Add(string.Join(", ", lista));

        }

        //SELECTIONSORT

        private void BtnInsertarSelectionSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAInsertarSelectionSort.Text, out int valor))
            {
                valoresIngresadosSelectionSort.Add(valor);
                MostrarListaEnListBoxSelectionSort(lstAntesOrdenarSelectionSort, valoresIngresadosSelectionSort);
                txtValorAInsertarSelectionSort.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarSelectionSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAEliminarSelectionSort.Text, out int valor))
            {
                valoresIngresadosSelectionSort.Remove(valor);
                MostrarListaEnListBoxSelectionSort(lstAntesOrdenarSelectionSort, valoresIngresadosSelectionSort);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrdenarSelectionSort_Click_1(object sender, EventArgs e)
        {
            selectionSort.InsertValues(valoresIngresadosSelectionSort.ToArray());
            var steps = selectionSort.SortStepByStep();

            foreach (var step in steps)
            {
                // Corregir aquí: Convertir la cadena a lista de enteros antes de mostrarla en el ListBox
                MostrarListaEnListBoxSelectionSort(lstDespuesOrdenarSelectionSort, step.Split(',').Select(int.Parse).ToList());
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarSelectionSort_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenarSelectionSort.Items.Clear();
            lstDespuesOrdenarSelectionSort.Items.Clear();
            valoresIngresadosSelectionSort.Clear();
        }

        // Método Auxiliar para Mostrar la Lista en un ListBox para Selection Sort
        private void MostrarListaEnListBoxSelectionSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.Add(string.Join(", ", lista));
        }

        //HEAPSORT

        private void BtnInsertarHeapSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAInsertarHeapSort.Text, out int valor))
            {
                valoresIngresadosHeapSort.Add(valor);
                MostrarListaEnListBoxHeapSort(lstAntesOrdenarHeapSort, valoresIngresadosHeapSort);
                txtValorAInsertarHeapSort.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarHeapSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAEliminarHeapSort.Text, out int valor))
            {
                valoresIngresadosHeapSort.Remove(valor);
                MostrarListaEnListBoxHeapSort(lstAntesOrdenarHeapSort, valoresIngresadosHeapSort);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrdenarHeapSort_Click_1(object sender, EventArgs e)
        {
            heapSort.InsertValues(valoresIngresadosHeapSort.ToArray());
            var steps = heapSort.SortStepByStep();

            foreach (var step in steps)
            {
                // Convierte la lista de enteros a una cadena antes de agregarla al ListBox
                lstDespuesOrdenarHeapSort.Items.Add(string.Join(", ", step));
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarHeapSort_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenarHeapSort.Items.Clear();
            lstDespuesOrdenarHeapSort.Items.Clear();
            valoresIngresadosHeapSort.Clear();
        }

        // Método Auxiliar para Mostrar la Lista en un ListBox para Heap Sort
        private void MostrarListaEnListBoxHeapSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.Add(string.Join(", ", lista));
        }

        //QUICKSORT

        private void BtnInsertarQuickSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAInsertarQuickSort.Text, out int valor))
            {
                valoresIngresadosQuickSort.Add(valor);
                MostrarListaEnListBoxQuickSort(lstAntesOrdenarQuickSort, valoresIngresadosQuickSort);
                txtValorAInsertarQuickSort.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarQuickSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorAEliminarQuickSort.Text, out int valor))
            {
                valoresIngresadosQuickSort.Remove(valor);
                MostrarListaEnListBoxQuickSort(lstAntesOrdenarQuickSort, valoresIngresadosQuickSort);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrdenarQuickSort_Click_1(object sender, EventArgs e)
        {
            quickSort.InsertValues(valoresIngresadosQuickSort.ToArray());
            var steps = quickSort.SortStepByStep();

            lstDespuesOrdenarQuickSort.Items.Clear(); // Limpiar el ListBox antes de agregar los pasos

            foreach (var step in steps)
            {
                // Convierte la lista de enteros a una cadena y agrega cada paso como un nuevo renglón
                lstDespuesOrdenarQuickSort.Items.Add(string.Join(", ", step));
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarQuickSort_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenarQuickSort.Items.Clear();
            lstDespuesOrdenarQuickSort.Items.Clear();
            valoresIngresadosQuickSort.Clear();
        }

        // Método Auxiliar para Mostrar la Lista en un ListBox para Quicksort
        private void MostrarListaEnListBoxQuickSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();

            foreach (var item in lista)
            {
                // Agrega cada elemento como un nuevo renglón
                listBox.Items.Add(item.ToString());
            }
        }

        //BUBBLESORT

        private void BtnInsertarBubbleSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorInsertarBubbleSort.Text, out int valorInsertar))
            {
                bubbleSort.InsertValue(valorInsertar);
                MostrarListaBubbleSort(lstAntesOrdenarBubbleSort, bubbleSort.GetArray());
                txtValorInsertarBubbleSort.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico para insertar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarBubbleSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorEliminarBubbleSort.Text, out int valorEliminar))
            {
                bubbleSort.DeleteValue(valorEliminar);
                MostrarListaBubbleSort(lstAntesOrdenarBubbleSort, bubbleSort.GetArray());
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrdenarBubbleSort_Click_1(object sender, EventArgs e)
        {
            var steps = bubbleSort.SortStepByStep();
            lstDespuesOrdenarBubbleSort.Items.Clear();

            foreach (var step in steps)
            {
                MostrarPasoBubbleSort(lstDespuesOrdenarBubbleSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarBubbleSort_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenarBubbleSort.Items.Clear();
            lstDespuesOrdenarBubbleSort.Items.Clear();
            txtValorInsertarBubbleSort.Clear();
            txtValorEliminarBubbleSort.Clear();
            bubbleSort = new BubbleSort(); // Reiniciar la instancia de BubbleSort
        }

        private void MostrarListaBubbleSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.Add(string.Join(", ", lista));
        }

        private void MostrarPasoBubbleSort(ListBox listBox, List<int> paso)
        {
            listBox.Items.Add(string.Join(", ", paso));
        }

        //COCKTAILSORT

        private void BtnInsertarCocktailSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorInsertarCocktailSort.Text, out int valorInsertar))
            {
                cocktailSort.InsertValue(valorInsertar);
                MostrarListaCocktailSort(lstAntesOrdenarCocktailSort, cocktailSort.GetArray());
                txtValorInsertarCocktailSort.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico para insertar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarCocktailSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorEliminarCocktailSort.Text, out int valorEliminar))
            {
                cocktailSort.DeleteValue(valorEliminar);
                MostrarListaCocktailSort(lstAntesOrdenarCocktailSort, cocktailSort.GetArray());
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrdenarCocktailSort_Click_1(object sender, EventArgs e)
        {
            var steps = cocktailSort.SortStepByStep();
            lstDespuesOrdenarCocktailSort.Items.Clear();

            foreach (var step in steps)
            {
                MostrarPasoCocktailSort(lstDespuesOrdenarCocktailSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarCocktailSort_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenarCocktailSort.Items.Clear();
            lstDespuesOrdenarCocktailSort.Items.Clear();
            txtValorInsertarCocktailSort.Clear();
            txtValorEliminarCocktailSort.Clear();
            cocktailSort = new CocktailSort();
        }

        private void MostrarListaCocktailSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.Add(string.Join(", ", lista));
        }

        private void MostrarPasoCocktailSort(ListBox listBox, List<int> paso)
        {
            listBox.Items.Add(string.Join(", ", paso));
        }

        //INSERTIONSORT

        private void BtnInsertarInsertionSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorInsertarInsertionSort.Text, out int valorInsertar))
            {
                insertionSort.InsertValue(valorInsertar);
                MostrarListaInsertionSort(lstAntesOrdenarInsertionSort, insertionSort.GetArray());
                txtValorInsertarInsertionSort.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico para insertar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarInsertionSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorEliminarInsertionSort.Text, out int valorEliminar))
            {
                insertionSort.DeleteValue(valorEliminar);
                MostrarListaInsertionSort(lstAntesOrdenarInsertionSort, insertionSort.GetArray());
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrdenarInsertionSort_Click_1(object sender, EventArgs e)
        {
            var steps = insertionSort.SortStepByStep();
            lstDespuesOrdenarInsertionSort.Items.Clear();

            foreach (var step in steps)
            {
                MostrarPasoInsertionSort(lstDespuesOrdenarInsertionSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarInsertionSort_Click_1(object sender, EventArgs e)
        {
            lstAntesOrdenarInsertionSort.Items.Clear();
            lstDespuesOrdenarInsertionSort.Items.Clear();
            txtValorInsertarInsertionSort.Clear();
            txtValorEliminarInsertionSort.Clear();
            insertionSort = new InsertionSort();
        }

        private void MostrarListaInsertionSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.Add(string.Join(", ", lista));
        }

        private void MostrarPasoInsertionSort(ListBox listBox, List<int> paso)
        {
            listBox.Items.Add(string.Join(", ", paso));
        }

        //COUNTINGSORT

        private void BtnInsertarCountingSort_Click_1(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(txtValorInsertarCountingSort.Text, out value))
            {
                countingSort.InsertValue(value);
                MostrarListaEnListBoxCountingSort(lstAntesOrdenarCountingSort, countingSort.GetArray());
                txtValorInsertarCountingSort.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnEliminarCountingSort_Click_1(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(txtValorEliminarCountingSort.Text, out value))
            {
                countingSort.DeleteValue(value);
                MostrarListaEnListBoxCountingSort(lstAntesOrdenarCountingSort, countingSort.GetArray());
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnOrdenarCountingSort_Click_1(object sender, EventArgs e)
        {
            var steps = countingSort.SortStepByStep();

            foreach (var step in steps)
            {
                MostrarListaEnListBoxCountingSort(lstDespuesOrdenarCountingSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarCountingSort_Click_1(object sender, EventArgs e)
        {
            countingSort = new CountingSort();
            LimpiarListBoxCountingSort(lstAntesOrdenarCountingSort);
            LimpiarListBoxCountingSort(lstDespuesOrdenarCountingSort);
        }

        private void MostrarListaEnListBoxCountingSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(lista.Select(item => item.ToString()).ToArray());
        }

        private void LimpiarListBoxCountingSort(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        //MERGESORT

        private void BtnInsertarMergeSort_Click_1(object sender, EventArgs e)
        {
            int value;

            // Verifica si el valor ingresado es un número válido
            if (int.TryParse(txtValorInsertarMergeSort.Text, out value))
            {
                mergeSort.InsertValue(value);
                MostrarListaEnListBoxMergeSort(lstAntesOrdenarMergeSort, mergeSort.GetArray());
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnEliminarMergeSort_Click_1(object sender, EventArgs e)
        {
            int value;

            // Verifica si el valor ingresado es un número válido
            if (int.TryParse(txtValorEliminarMergeSort.Text, out value))
            {
                mergeSort.DeleteValue(value);
                MostrarListaEnListBoxMergeSort(lstAntesOrdenarMergeSort, mergeSort.GetArray());
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnOrdenarMergeSort_Click_1(object sender, EventArgs e)
        {
            var steps = mergeSort.SortStepByStep();

            foreach (var step in steps)
            {
                // Convierte la lista de enteros a una cadena antes de agregarla al ListBox
                MostrarListaEnListBoxMergeSort(lstDespuesOrdenarMergeSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarMergeSort_Click_1(object sender, EventArgs e)
        {
            mergeSort = new MergeSort();
            LimpiarListBoxMergeSort(lstAntesOrdenarMergeSort);
            LimpiarListBoxMergeSort(lstDespuesOrdenarMergeSort);
        }

        private void LimpiarListBoxMergeSort(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        // Método para mostrar una lista en un ListBox asociado a Merge Sort
        private void MostrarListaEnListBoxMergeSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(lista.Select(item => item.ToString()).ToArray());
        }

        //BINARYTREESORT

        private void BtnInsertarBinaryTreeSort_Click_1(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(txtValorInsertarBinaryTreeSort.Text, out value))
            {
                binaryTreeSort.Insert(value);
                MostrarListaEnListBoxBinaryTreeSort(lstAntesOrdenarBinaryTreeSort, binaryTreeSort.InOrderTraversal());
                txtValorInsertarBinaryTreeSort.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnEliminarBinaryTreeSort_Click_1(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(txtValorEliminarBinaryTreeSort.Text, out value))
            {
                binaryTreeSort.Delete(value);
                MostrarListaEnListBoxBinaryTreeSort(lstAntesOrdenarBinaryTreeSort, binaryTreeSort.InOrderTraversal());
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnOrdenarBinaryTreeSort_Click_1(object sender, EventArgs e)
        {
            MostrarListaEnListBoxBinaryTreeSort(lstDespuesOrdenarBinaryTreeSort, binaryTreeSort.InOrderTraversal());
        }

        private void btnLimpiarBinaryTreeSort_Click(object sender, EventArgs e)
        {
            binaryTreeSort = new BinaryTreeSort();
            LimpiarListBoxBinaryTreeSort(lstAntesOrdenarBinaryTreeSort);
            LimpiarListBoxBinaryTreeSort(lstDespuesOrdenarBinaryTreeSort);
        }

        private void LimpiarListBoxBinaryTreeSort(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        // Método para mostrar una lista en un ListBox asociado a Binary Tree Sort
        private void MostrarListaEnListBoxBinaryTreeSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(lista.Select(item => item.ToString()).ToArray());
        }

        //RADIXSORT

        private void BtnInsertarRadixSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorInsertarRadixSort.Text, out int value))
            {
                numbersToSort.Add(value);
                MostrarListaEnListBoxRadixSort(lstAntesOrdenarRadixSort, numbersToSort);
                txtValorInsertarRadixSort.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnEliminarRadixSort_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtValorEliminarRadixSort.Text, out int value))
            {
                numbersToSort.Remove(value);
                MostrarListaEnListBoxRadixSort(lstAntesOrdenarRadixSort, numbersToSort);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnOrdenarRadixSort_Click_1(object sender, EventArgs e)
        {
            sortingSteps = radixSort.SortStepByStep(numbersToSort);
            // Mostrar los pasos intermedios en el ListBox
            foreach (var step in sortingSteps)
            {
                MostrarListaEnListBoxRadixSort(lstDespuesOrdenarRadixSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void BtnLimpiarRadixSort_Click_1(object sender, EventArgs e)
        {
            numbersToSort.Clear();
            LimpiarListBoxRadixSort(lstAntesOrdenarRadixSort);
            LimpiarListBoxRadixSort(lstDespuesOrdenarRadixSort);
        }

        private void MostrarListaEnListBoxRadixSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(lista.Select(item => item.ToString()).ToArray());
        }

        private void LimpiarListBoxRadixSort(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        //GNOMESORT

        // Método para mostrar una lista en un ListBox asociado a Gnome Sort
        private void MostrarListaEnListBoxGnomeSort(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(lista.Select(item => item.ToString()).ToArray());
        }

        // Método para limpiar un ListBox asociado a Gnome Sort
        private void LimpiarListBoxGnomeSort(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        private void BtnInsertarGnomeSort_Click_1(object sender, EventArgs e)
        {
            int value;

            // Verifica si el valor ingresado es un número válido
            if (int.TryParse(txtValorInsertarGnomeSort.Text, out value))
            {
                gnomeSort.InsertValue(value);
                MostrarListaEnListBoxGnomeSort(lstAntesOrdenarGnomeSort, gnomeSort.GetArray());
                txtValorInsertarGnomeSort.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnOrdenarGnomeSort_Click_1(object sender, EventArgs e)
        {
            var steps = gnomeSort.SortStepByStep();

            // Muestra los pasos intermedios
            foreach (var step in steps)
            {
                MostrarListaEnListBoxGnomeSort(lstDespuesOrdenarGnomeSort, step);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);  // Pausa para una visualización más clara
            }
        }

        private void BtnLimpiarGnomeSort_Click_1(object sender, EventArgs e)
        {
            gnomeSort = new GnomeSort();
            LimpiarListBoxGnomeSort(lstAntesOrdenarGnomeSort);
            LimpiarListBoxGnomeSort(lstDespuesOrdenarGnomeSort);
        }

        //MEZCLANATURAL

        // Evento del botón para insertar un valor
        //private void BtnInsertarMezclaNatural_Click(object sender, EventArgs e)
        //{
        //    int value;

        //    // Verifica si el valor ingresado es un número válido
        //    if (int.TryParse(txtValorInsertarMezclaNatural.Text, out value))
        //    {
        //        mezclaNatural.InsertValue(value);
        //        MostrarListaEnListBoxMezclaNatural(lstAntesOrdenarMezclaNatural, mezclaNatural.GetArray());
        //        txtValorInsertarMezclaNatural.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, ingrese un valor numérico válido.");
        //    }
        //}

        // Evento del botón para ordenar
        //private void BtnOrdenarMezclaNatural_Click(object sender, EventArgs e)
        //{
        //    // Inicia el proceso de ordenamiento
        //    mezclaNatural.Sort();

        //    // Muestra el resultado en ListBox
        //    MostrarListaEnListBoxMezclaNatural(lstDespuesOrdenarMezclaNatural, mezclaNatural.GetArray());
        //}

        // Evento del botón para limpiar
        //private void BtnLimpiarMezclaNatural_Click(object sender, EventArgs e)
        //{
        //    mezclaNatural = new MezclaNatural();
        //    LimpiarListBoxMezclaNatural(lstAntesOrdenarMezclaNatural);
        //    LimpiarListBoxMezclaNatural(lstDespuesOrdenarMezclaNatural);
        //}

        // Método para limpiar un ListBox asociado a Mezcla Natural
        private void LimpiarListBoxMezclaNatural(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        // Método para mostrar una lista en un ListBox asociado a Mezcla Natural
        private void MostrarListaEnListBoxMezclaNatural(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(lista.Select(item => item.ToString()).ToArray());
        }

        private void BtnInsertarMezclaNatural_Click_1(object sender, EventArgs e)
        {
            int value;

            // Verifica si el valor ingresado es un número válido
            if (int.TryParse(txtValorInsertarMezclaNatural.Text, out value))
            {
                mezclaNatural.InsertValue(value);
                MostrarListaEnListBoxMezclaNatural(lstAntesOrdenarMezclaNatural, mezclaNatural.GetArray());
                txtValorInsertarMezclaNatural.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.");
            }
        }

        private void BtnOrdenarMezclaNatural_Click_1(object sender, EventArgs e)
        {
            // Inicia el proceso de ordenamiento
            mezclaNatural.Sort();

            // Muestra el resultado en ListBox
            MostrarListaEnListBoxMezclaNatural(lstDespuesOrdenarMezclaNatural, mezclaNatural.GetArray());
        }

        private void BtnLimpiarMezclaNatural_Click_1(object sender, EventArgs e)
        {
            mezclaNatural = new MezclaNatural();
            LimpiarListBoxMezclaNatural(lstAntesOrdenarMezclaNatural);
            LimpiarListBoxMezclaNatural(lstDespuesOrdenarMezclaNatural);
        }
    }
}
