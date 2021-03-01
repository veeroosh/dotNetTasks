using System;

namespace List {
    class Node {
        public int data;
        public Node next = null;
        public Node prev = null;
        
        public Node() {}
        public Node(int data) {
            this.data = data;
        }
    }
    
    class List {
        private Node head;
        private Node tail;

        public List() {}

        static void Main(string[] args) {
            List list = new List();
            
            list.init(new []{0, 1, 2, 3, 4, 5}, 6);
            Console.Write("Initialized list: ");
            list.show();
            
            list.add(6);
            Console.Write("Added 6: ");
            list.show();
            
            list.remove(6);
            Console.Write("Removed 6: ");
            list.show();
            
            list.remove(0);
            Console.Write("Removed 0: ");
            list.show();
            
            list.remove(3);
            Console.Write("Removed 3: ");
            list.show();
            
            list.add(7);
            Console.Write("Added 7: ");
            list.show();
            
            list.reverse();
            Console.Write("Reversed list: ");
            list.show();
        }

        private void show()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.Write('\n');
        }
        private void init(int[] data, int size)
        {
            if (size == 0)
                return;
            
            if (head != null)
                return;

            head = new Node(data[0]);
            Node current = head;

            for (int i = 1; i < size; ++i)
            {
                Node temp = new Node(data[i]);
                temp.prev = current;
                current.next = temp;
                current = current.next;
            }

            tail = current;
        }
        
        private void add(int data)
        {
            Node newElement = new Node(data);

            if (head == null)
                head = newElement;
            else
            {
                tail.next = newElement;
                newElement.prev = tail;
            }

            tail = newElement;
            //++size;
        }

        private bool remove(int data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.data == data)
                    break;
                else
                    current = current.next;
            }

            if (current == null)
                return false;
            else {
                if (current == head)
                {
                    head = head.next;
                    head.prev = null;
                }
                else if (current == tail)
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                else {
                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                }
                //--size;
                return true;
            }
        }

        private void reverse()
        {
            if (head == null)
                return;
            
            List newList = new List();
            newList.head = new Node(tail.data);

            Node current = tail.prev,
                currentNew = newList.head;

            while (current != null)
            {
                currentNew.next = new Node(current.data);
                currentNew.next.prev = currentNew;
                currentNew = currentNew.next;

                current = current.prev;
            }

            head = newList.head;
            tail = currentNew;
        }
        
    }
}