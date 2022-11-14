namespace BinaryTreeImplementation
{
    public class BinaryTreeInOrderPostOrder
    {
        public BinaryTree BuildTree(int[] inorder, int[] postorder) {
        Dictionary<int, int> inorderDict = new Dictionary<int, int>();
        for(int i=0;i<inorder.Length;i++)
		{
			inorderDict.Add(inorder[i],i);
		}
        return CreateTree(inorderDict, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
    }

    private BinaryTree CreateTree(Dictionary<int, int> inorder, int[] postorder, int inStart, int inEnd, int postStart, int postEnd)
    {
        if (inStart > inEnd || postStart > postEnd)
            {
                return null;
            }
            int midVal = postorder[postEnd];
            int midValIndexInInOrder = inorder[midVal];
            int remaining = midValIndexInInOrder - inStart;
            
            BinaryTree node = new BinaryTree(midVal);

            // if (midValIndexInInOrder > inStart)
            // {
                node.left = CreateTree(inorder, postorder, inStart, midValIndexInInOrder - 1, postStart, postStart + remaining - 1);
            // }
            // if (postEnd > postStart)
            // {
                node.right = CreateTree(inorder, postorder, midValIndexInInOrder + 1, inEnd, postStart + remaining, postEnd - 1);
            // }
            return node;
    }
    }
}