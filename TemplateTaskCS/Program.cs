using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTaskCSharp
{
    class Program //second branch
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(1, 5);
            for (int i = 2; i <= 5; ++i) first.push(i);
            Queue<int> second = new Queue<int>(7, 5);
            for (int i = 8; i <= 11; ++i) second.push(i);
            first.print(); //print the first queue
            first.pop(); //delete an element from the first queue
            first.print(); //print the first queue after deleting an element
            first.unite(second); //unite the queues
            first.print(); //print the united queues
            Console.Read();
        }
    }
}
