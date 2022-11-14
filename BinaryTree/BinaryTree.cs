using System.Collections.Generic;

namespace BinaryTreeImplementation
{
    public class BinaryTree
    {
        public BinaryTree(int value, BinaryTree? left = null, BinaryTree? right = null)
        {
            this.left = left;
            this.right = right;
            this.value = value;
        }
        public BinaryTree? left { get; set; }
        public BinaryTree? right { get; set; }
        public int value { get; }

        public void GetInOrder(BinaryTree? root)
        {
            if (root == null)
            {
                return;
            }
            GetInOrder(root.left);
            Console.WriteLine(root.value);
            GetInOrder(root.right);
        }

        public void GetPostOrder(BinaryTree? root)
        {
            if(root == null)
            {
                return;
            }
            GetPostOrder(root.left);
            GetPostOrder(root.right);
            Console.WriteLine(root.value);
        }

        public void GetPreOrder(BinaryTree? root)
        {
            if(root == null)
            {
                return;
            }
            Console.WriteLine(root.value);
            GetPreOrder(root.left);
            GetPreOrder(root.right);
        }

        public void GetLevelOrder(BinaryTree root)
        {
            if (root == null)
            {
                return;
            }
            Queue<BinaryTree> queue = new Queue<BinaryTree>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                BinaryTree top = queue.Dequeue();

                Console.WriteLine(top.value);    
                if (top.left != null)
                {
                    queue.Enqueue(top.left);
                }
                if (top.right != null)
                {
                    queue.Enqueue(top.right);
                }
            }
        }

        private BinaryTree? parent = null;
        private bool isParentFound = false;
        private BinaryTree? ConvertToInOrderDLL(BinaryTree? root)
        {
            if (root == null)
            {
                return null;
            }
            ConvertToInOrderDLL(root.left);
            if (!isParentFound)
            {
                parent = root;
                isParentFound = true;
            }
            else 
            {
                root.left = parent;
                parent.right = root;
                parent = root;
            }
            ConvertToInOrderDLL(root.right);
            return parent;
        }
        public BinaryTree? GetInOrderDLL(BinaryTree? root)
        {
            if (root == null)
            {
                return null;
            }
            isParentFound = false;
            BinaryTree? resultDLL = ConvertToInOrderDLL(root);
            while(resultDLL?.left != null)
            {
                resultDLL = resultDLL.left;
            }
            return resultDLL;
        }
    }
}