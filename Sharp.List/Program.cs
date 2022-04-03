using System;

namespace Sharp.List
{
    class Program
    {

        static void Main(string[] args)
        {

            List list = new List("alphbet");

            list.AddNode('a', 0);
            list.AddNode('b', 1);
            list.AddNode('c', 2);
            list.AddNode('d', 3);
            list.AddNode('e', 4);
            list.AddNode('f', 5);

            list.ExcludeByAlphabet();

            list.Print();

        }

    }

}
