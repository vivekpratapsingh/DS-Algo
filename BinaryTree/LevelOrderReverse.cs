using System.Collections.Generic;

namespace BinaryTreeImplementation
{
    public class LevelOrderReverseTraversal
    {
        public IList<IList<int>> LevelOrderBottom(BinaryTree root)
        {
            List<IList<int>> list = new List<IList<int>>();
            if (root == null)
            {
                return new List<IList<int>>();
            }
            Queue<BinaryTree> q = new Queue<BinaryTree>();
            Stack<int?> s = new Stack<int?>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 0)
            {
                int size = q.Count;
                bool isPushed = false;
                for (int i = 0; i < size; i++)
                {
                    BinaryTree node = q.Dequeue();
                    if (node == null)
                    {
                        if (isPushed == true)
                        {
                            q.Enqueue(null);
                            s.Push(null);
                        }
                    }
                    else
                    {
                        if (node.right != null)
                        {
                            isPushed = true;
                            q.Enqueue(node.right);
                        }
                        if (node.left != null)
                        {
                            isPushed = true;
                            q.Enqueue(node.left);
                        }
                        s.Push(node.value);
                    }
                }
                s.Push(null);
            }

            IList<int> subList = new List<int>();
            bool isNull = false;
            foreach (int? num in s)
            {
                if (num == null)
                {
                    if (isNull == true)
                    {
                        list.Add(subList);
                    }
                    subList = new List<int>();
                    isNull = true;
                }
                else
                {
                    subList.Add(Convert.ToInt32(num));
                }
            }
            list.Add(subList);
            return list;
        }
    }
}