using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTaskCSharp
{
    unsafe class Queue<T>
    {
        private int max = 0;
        private T data;
        private bool first = false;
        private Queue<T> next = null;

        public Queue(T d, int _max)
        {
            if (_max == 0)
            {
                Console.WriteLine("Length can't be smaller than 1. Maximum length will be set to 1");
                _max = 1;
            }
            this.data = d;
            this.max = _max;
            this.next = null;
            this.first = true;
        }
        public Queue(T d)
        {
            this.data = d;
            this.max = 0;
            this.next = null;
        }

        public void push(T d)//counts the number of elements in the queue
        {
            if (this.first == true)
            {
                if (this.count(0) < this.max) //checking if maximum number of elements is reached   
                {
                    if (this.next == null) this.next = new Queue<T>(d);//if this is the last element, a new element is created
                    else this.next.push(d);
                }
                else
                {
                    Console.Write("Maximum number of elements is reached");
                }
            }
            else
            {
                if (this.next == null) this.next = new Queue<T>(d);
                else this.next.push(d);
            }
        }
        public void pop() //deleting the first element
        {
            if (this.next != null)
            {
                if (this.next.next != null) //searching for the penultimate element
                {
                    this.data = this.next.data;
                    this.next.pop();
                }
                else //when it is found, it's data becomes the last element's data
                {
                    this.data = this.next.data;
                    this.next = null;//and it's pointer becomes null
                    return;
                }
            }
        }
        public void unite(Queue<T> s)//uniting the queues
        {
            if (this.next != null)//searching for the last element of the first queue
            {
                this.max += s.max;
                this.next.unite(s);
            }
            else
            {
                this.next = s;         // the first element of the second queue is attached
                s.first = false;         //the first element of the second queue is no longer the first
                return;
            }
        }

        public void print()
        {
            if (this.next != null)
            {
                Console.Write(this.data + "  ");
                this.next.print();
            }
            else
            {
                Console.Write(this.data);
                Console.WriteLine();
            }
        }

        public int count(int i) //counts the number of elements in the queue
        {
            bool met = false;
            ++i;
            if (this.next != null && met == false) { met = true; return this.next.count(i); }
            else return i;
        }
    }
}
