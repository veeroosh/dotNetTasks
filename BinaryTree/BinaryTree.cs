using System;

namespace BinaryTree
{
    class Node
    {
        public int data;
        public Node parent = null;
        public Node left = null;
        public Node right = null;
        
        public Node() {}

        public Node(int data)
        {
            this.data = data;
        }
    }

    public class BinaryTree
    {
        private Node head;
        
        static void Main(string[] args) {
            BinaryTree tree = new BinaryTree();
            
            tree.add(6);
            Console.Write("Added 6: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(5);
            Console.Write("Added 5: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(10);
            Console.Write("Added 10: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(8);
            Console.Write("Added 8: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(1);
            Console.Write("Added 1: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(16);
            Console.Write("Added 16: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(0);
            Console.Write("Added 0: ");
            tree.show(tree.head);
            Console.WriteLine();

            Node search = tree.search(7, tree.head);
            Console.Write("Search 7: ");
            if (search == null) Console.WriteLine("not found");
            else Console.WriteLine("found");
            
            search = tree.search(1, tree.head);
            Console.Write("Search 1: ");
            if (search == null) Console.WriteLine("not found");
            else Console.WriteLine("found");
            
            tree.remove(6);
            Console.Write("Removed 6: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.remove(16);
            Console.Write("Removed 16: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.remove(8);
            Console.Write("Removed 8: ");
            tree.show(tree.head);
            Console.WriteLine();
        }

        private void show(Node node)
        {
            if (head == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
                
            if (node != null)
            {
                Console.Write(node.data + " ");
                show(node.left);
                show(node.right);
            }
        }
        
        private void add(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return;
            }
            
            Node current = head;
            
            while (current != null)
            {
                if (data > current.data)
                {
                    if (current.right != null)
                        current = current.right;
                    else
                    {
                        current.right = new Node(data);
                        current.right.parent = current;
                        current = current.right.right;
                    }
                }
                else
                {
                    if (current.left != null)
                        current = current.left;
                    else
                    {
                        current.left = new Node(data);
                        current.left.parent = current;
                        current = current.left.right;
                    }
                }
            }
        }

        private Node search(int data, Node node)
        {
            if (node == null || node.data == data)
                return node;

            if (data < node.data)
                return search(data, node.left);
            else
                return search(data, node.right);
        }

        private Node minimum(Node node)
        {
            if (node.left == null)
                return node;
            return minimum(node.left);
        }

        private Node next(Node node)
        {
            if (node.right != null)
                return minimum(node.right);
            Node parent = node.parent;
            while (parent != null && node == parent.right)
            {
                node = parent;
                parent = parent.parent;
            }

            return parent;
        }
        
        private void remove(int data)
        {
            if (head == null)
                return;

            Node node = search(data, head);
            Node parent = node.parent;

            if (node.left == null && node.right == null) // node - leaf
            {
                if (parent.left == node)
                    parent.left = null;
                if (parent.right == node)
                    parent.right = null;
            } else if (node.left == null || node.right == null) // one child
            {
                if (node.left == null)
                {
                    if (parent.left == node)
                        parent.left = node.right;
                    else
                        parent.right = node.right;
                    node.right.parent = parent;
                }
                else
                {
                    if (parent.left == node)
                        parent.left = node.left;
                    else
                        parent.right = node.left;
                    node.left.parent = parent;
                }
            }
            else // both children
            {
                Node child = next(node);
                node.data = child.data;

                if (child.parent.left == child)
                {
                    child.parent.left = child.right;
                    if (child.right != null)
                        child.right.parent = child.parent;
                }
                else
                {
                    child.parent.right = child.left;
                    if (child.left != null)
                        child.right.parent = child.parent;
                }
            }
        }
        
    }
}