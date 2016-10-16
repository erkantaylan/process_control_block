using System;
using System.Threading;

using OperationSystems.DataStructures;

namespace operation_system_homework {

    internal static class Program {

        private static void Main(string[] args) {
            var list = new LinkedQueue<int>();
            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);
            list.Enqueue(4);
            list.Enqueue(5);
            list.Enqueue(6);
            list.Enqueue(7);

            while (!list.IsQueueEmpty()) {
                Console.WriteLine(list);
                Console.WriteLine(list.Dequeue().Value);
            }

            End();
        }

        private static void End() {
            Console.WriteLine(" - Fin -");
            Console.WriteLine("Do not press any key!");
            Console.ReadKey(true);
            Console.WriteLine("Bye!");
            Thread.Sleep(500);
        }

    }

}