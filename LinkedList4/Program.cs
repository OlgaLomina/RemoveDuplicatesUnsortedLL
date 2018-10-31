using System;
using System.Collections;
/*Write code to remove duplicates from an unsorted linked list.
*Follow up: How would you solve it if temporary buffer is not allowed?*/

namespace LinkedList4
{
    public class Node<T>
    {
        public Node<T> next;
        public T data;

        public Node()
        {
            next = null;
        }
        public Node(T value)
        {
            data = value;
            next = null;
        }
    }

    public class MyLL<T>
    {
        Node<T> head;

        public MyLL()
        {
            head = null;
        }

        public void printAllNodes()
        {
            Node<T> cur = head;
            while (cur.next != null)
            {
                Console.WriteLine(cur.data);
                cur = cur.next;
            }
            Console.WriteLine(cur.data);
            Console.WriteLine();
        }

        public void AddHead(T d)
        {
            Node<T> node = new Node<T>(d);
            node.next = head;
            head = node;
        }

        public void RemoveDuplicate()
        {
            Node<T> cur = head;
            T dat1 = cur.data;
            Hashtable myHT = new Hashtable();
            myHT.Add(dat1, 1);

            while (cur.next != null)
            {
                dat1 = cur.next.data;
                if (!myHT.ContainsKey(dat1))
                {
                    myHT.Add(dat1, 1);
                }
                else
                {
                    cur.next = cur.next.next;
                }
                cur = cur.next;
            }           
        }

        public void RemoveDuplicate2()
        {
            Node<T> prev = head, cur;
            T dat1, dat2;
            while (prev != null && prev.next != null)
            {
                cur = prev;
                while (cur.next != null)
                {
                    dat1 = prev.data;
                    dat2 = cur.next.data;
                    if (dat1.Equals(dat2))
                    {
                        cur.next = cur.next.next; //delete dublicate
                    }
                    else
                        cur = cur.next;
                }
                prev = prev.next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyLL<char> list = new MyLL<char>();
            list.AddHead('3');
            list.AddHead('1');
            list.AddHead('4');
            list.AddHead('3');
            list.AddHead('2');
            list.AddHead('2');
            list.AddHead('8');

            list.printAllNodes();

            list.RemoveDuplicate2();

            list.printAllNodes();
        }
    }
}
