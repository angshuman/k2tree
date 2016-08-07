using System;
using TripleStore.Graph;

namespace Run
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tree = new K2Tree(32);

            tree.Set(1234, 4321);
            tree.Set(1234, 43214321);
            tree.Set(1234, 9876);

            tree.Set(1111, 9876);
            tree.Set(2222, 9876);
            tree.Set(3333, 9876);

            Console.WriteLine(string.Join(" ", tree.GetByX(1234)));
            Console.WriteLine(string.Join(" ", tree.GetByY(9876)));
            Console.ReadLine();
        }
    }
}
