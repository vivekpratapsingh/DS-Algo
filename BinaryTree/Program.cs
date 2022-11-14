// See https://aka.ms/new-console-template for more information
using BinaryTreeImplementation;

// Console.WriteLine("Hello, World!");

BinaryTreeInOrderPostOrder binaryTreeInOrderPostOrder = new BinaryTreeInOrderPostOrder();
// int[] inorder = new int[] {9,3,15,20,7};
// int[] postorder = new int[] {9,15,7,20,3};
int[] inorder = new int[] {2,1};
int[] postorder = new int[] {2,1};
BinaryTree root = binaryTreeInOrderPostOrder.BuildTree(inorder, postorder);
root.GetLevelOrder(root);