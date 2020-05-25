using System;
using Comparator;

namespace BinarySearchTree
{
    class BinaryTreeNode<T>
    {
        public T data;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public BinaryTreeNode(T _data, BinaryTreeNode<T> _left, BinaryTreeNode<T> _right)
        {
            data = _data;
            left = _left;
            right = _right;
        }
    }


    class BinarySearchTree<T>
    {

        public BinaryTreeNode<T> root;
        Comparator<T> comparator;

        public BinarySearchTree(Comparator<T> _comparator)
        {
            comparator = _comparator;
        }

        public void insert(T data)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(data, null, null);
            if (root is null) root = node;
            else
            {
                insertNode(root, node);
            }
        }

        public void insertNode(BinaryTreeNode<T> toNode, BinaryTreeNode<T> node)
        {
            if (toNode is null) throw new Exception();

            if (comparator.lessThanOrEqual(node.data, toNode.data))
            {
                if (toNode.left is null)
                {
                    toNode.left = node;
                }
                else
                {
                    insertNode(toNode.left, node);
                }
            }
            else
            {
                if (toNode.right is null)
                {
                    toNode.right = node;
                }
                else
                {
                    insertNode(toNode.right, node);
                }
            }
        }

        public void remove(T data)
        {
            root = removeNode(root, data);
        }

        public BinaryTreeNode<T> getMinNode(BinaryTreeNode<T> node)
        {
            if (node.left is null) return node;
            return getMinNode(node.left);
        }

        public BinaryTreeNode<T> removeNode(BinaryTreeNode<T> fromNode, T data)
        {
            if (comparator.lessThan(data, fromNode.data))
            {
                fromNode.left = removeNode(fromNode.left, data);
                return fromNode;
            }
            else if (comparator.greaterThan(data, fromNode.data))
            {
                fromNode.right = removeNode(fromNode.right, data);
                return fromNode;
            }
            else
            {
                if (fromNode.left is null && fromNode.right is null)
                {
                    fromNode = null;
                    return null;
                }
                else if (fromNode.right is null)
                {
                    fromNode = fromNode.left;
                    return fromNode;
                }
                else if (fromNode.left is null)
                {
                    fromNode = fromNode.right;
                    return fromNode;
                }
                else
                {
                    BinaryTreeNode<T> rightMin = getMinNode(fromNode.right);

                    fromNode.data = rightMin.data;
                    fromNode.right = removeNode(fromNode.right, rightMin.data);

                    return fromNode;
                }
            }
        }

        public void inOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                inOrderTraversal(node.left);
                Console.Write(node.data + " ");
                inOrderTraversal(node.right);
            }
        }
        public void preOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.data + " ");
                preOrderTraversal(node.left);
                preOrderTraversal(node.right);
            }
        }
        public void postOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                postOrderTraversal(node.left);
                postOrderTraversal(node.right);
                Console.Write(node.data + " ");
            }
        }

        public BinaryTreeNode<T> getRootNode()
        {
            return root;
        }
    }

    static class Test
    {
        static public void test()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(new Int32Comparator());
            bst.insert(15);
            bst.insert(25);
            bst.insert(10);
            bst.insert(7);
            bst.insert(22);
            bst.insert(17);
            bst.insert(13);
            bst.insert(5);
            bst.insert(9);
            bst.insert(27);


            //          15
            //         /  \
            //        10   25
            //       / \   / \
            //      7  13 22  27
            //     / \    /
            //    5   9  17

            // prints 5 7 9 10 13 15 17 22 25 27
            bst.inOrderTraversal(bst.root);

            // Removing node with no children
            bst.remove(5);

            //          15
            //         /  \
            //        10   25
            //       / \   / \
            //      7  13 22  27
            //       \    /
            //        9  17

            // prints 7 9 10 13 15 17 22 25 27
            bst.inOrderTraversal(bst.root);

            // Removing node with one children
            bst.remove(7);

            //          15
            //         /  \
            //        10   25
            //       / \   / \
            //      9  13 22  27
            //            /
            //           17

            // prints 9 10 13 15 17 22 25 27
            bst.inOrderTraversal(bst.root);

            bst.remove(15);

            //          17
            //         /  \
            //        10   25
            //       / \   / \
            //      9  13 22  27

            Console.WriteLine("inorder traversal");
            bst.inOrderTraversal(bst.root);
            Console.WriteLine("preorder traversal");
            bst.preOrderTraversal(bst.root);
            Console.WriteLine("postorder traversal");
            bst.postOrderTraversal(bst.root);

            // Credit: test cases are copied from https://www.geeksforgeeks.org/implementation-binary-search-tree-javascript/

        }
    }
}