using System;
using System.Collections.Generic;
using System.Text;

namespace Sharp.List
{

    class Node
    {

        public char value { get; set; }
        public Node prev { get; set; }
        public Node next { get; set; }

        public Node(char value)
        {

            this.value = value;
            prev = null;
            next = null;

        }

    }

    class List
    {

        private string alphabet { get; set; }
        private Node root { get; set; }
        private Node tail { get; set; }
        private int count { get; set; }

        public List(string alphabet)
        {

            this.alphabet = alphabet;
            root = null;
            tail = null;
            count = 0;

        }

        public void AddNode(char value, int pos)
        {

            if (pos < 0 || pos > count)
            {

                Console.WriteLine($"Не удалось добавить элемент на позицию {pos}");

                return;

            }

            Node node = new Node(value);

            if (root == null)
            {

                root = node;
                tail = node;

            }
            else if (pos == count)
            {

                Node last = tail;

                node.prev = last;
                last.next = node;

                tail = node;

            }
            else if (pos == 0)
            {

                Node first = root;

                first.prev = node;
                node.next = first;

                root = node;

            }
            else
            {

                int counter = 0;

                Node current = root;

                while (counter != pos)
                {

                    current = current.next;

                    counter++;

                }

                current.prev.next = node;

                node.next = current;
                node.prev = current.prev;

                current.prev = node;

            }

            count++;

        }

        public void Print()
        {

            Node current = root;

            if (root == null)
            {

                Console.WriteLine("Список пуст");

                return;

            }

            while (current != null)
            {

                Console.Write($"{current.value} ");

                current = current.next;

            }

            Console.WriteLine();

        }

        public void Delete(int pos)
        {

            if (pos < 0 || pos > count || root == null)
            {

                Console.WriteLine($"Не удалось удалить элемент на позиции {pos}");

                return;

            }

            if (pos == count - 1)
            {

                Node last = tail.prev;

                if (last != null)
                {

                    last.next = null;

                    tail.prev = null;
                    tail.next = null;

                    tail = last;

                }
                else
                {

                    root = null;
                    tail = null;

                }

            }
            else if (pos == 0)
            {

                Node first = root.next;
                first.prev = null;

                root.next = null;
                root.prev = null;


                root = first;

            }
            else
            {

                int counter = 0;

                Node current = root;

                while (counter != pos)
                {

                    current = current.next;

                    counter++;

                }

                Node left = current.prev;
                Node right = current.next;

                left.next = right;
                right.prev = left;

                if (left.prev == null)
                    root = left;

                if (right.next == null)
                    tail = right;

            }

            count--;

        }

        public void ExcludeByAlphabet()
        {

            bool isClear = false;

            while (!isClear)
            {

                Node current = root;

                bool nodeDeleted = false;

                for (int i = 0; i < count; i++)
                {

                    char value = current.value;

                    if (alphabet.Contains(value))
                    {

                        this.Delete(i);

                        nodeDeleted = true;

                        break;

                    }

                    current = current.next;

                }

                if (!nodeDeleted)
                    isClear = true;

            }

        }

    }

}