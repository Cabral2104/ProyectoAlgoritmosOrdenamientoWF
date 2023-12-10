using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlgoritmosOrdenamientoWF
{
    public class BinaryTreeSort
    {
        private Node root;
        private List<List<int>> steps;


        public BinaryTreeSort()
        {
            root = null;
            steps = new List<List<int>>();
        }

        public void Insert(int value)
        {
            root = InsertRec(root, value);
            CaptureStep();
        }


        private Node InsertRec(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.Value)
                root.Left = InsertRec(root.Left, value);
            else if (value > root.Value)
                root.Right = InsertRec(root.Right, value);

            return root;
        }

        public List<int> InOrderTraversal()
        {
            List<int> result = new List<int>();
            InOrderTraversalRec(root, result);
            return result;
        }

        private void InOrderTraversalRec(Node root, List<int> result)
        {
            if (root != null)
            {
                InOrderTraversalRec(root.Left, result);
                result.Add(root.Value);
                InOrderTraversalRec(root.Right, result);
            }
        }

        public List<List<int>> GetSortingSteps()
        {
            return steps;
        }

        private void CaptureStep()
        {
            List<int> step = new List<int>();
            InOrderTraversalRec(root, step);
            steps.Add(new List<int>(step));
        }

        public void Delete(int value)
        {
            root = Delete(root, value);
        }

        private Node Delete(Node root, int value)
        {
            if (root == null)
                return root;

            // Recursivamente buscar el nodo a eliminar
            if (value < root.Value)
                root.Left = Delete(root.Left, value);
            else if (value > root.Value)
                root.Right = Delete(root.Right, value);
            else
            {
                // Nodo con solo un hijo o sin hijos
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // Nodo con dos hijos: obtener el sucesor inorden (el menor en el subárbol derecho)
                root.Value = MinValue(root.Right);

                // Eliminar el sucesor inorden
                root.Right = Delete(root.Right, root.Value);
            }

            return root;
        }

        private int MinValue(Node root)
        {
            int minValue = root.Value;
            while (root.Left != null)
            {
                minValue = root.Left.Value;
                root = root.Left;
            }
            return minValue;
        }
    }
}
