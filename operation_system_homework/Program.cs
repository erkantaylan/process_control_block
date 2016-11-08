using System;
using System.IO;
using System.Threading;
using Dependencies;
using Library.Parser;
using Models;
using OperationSystems.DataStructures;

namespace operation_system_homework {

    internal static class Program {

        private static void pain() {
            IProcess p1 = new ProcessControlBlock { ArrivalTime = 5, BurstTime = 25, Name = "Process A" };
            IProcess p2 = new ProcessControlBlock { ArrivalTime = 1, BurstTime = 53, Name = "Process B" };
            IProcess p3 = new ProcessControlBlock { ArrivalTime = 3, BurstTime = 27, Name = "Process C" };
            IProcess p4 = new ProcessControlBlock { ArrivalTime = 4, BurstTime = 12, Name = "Process D" };
            IProcess p5 = new ProcessControlBlock { ArrivalTime = 2, BurstTime = 69, Name = "Process E" };
            /*
            #region FCFS
            Console.WriteLine("# FCFS");
            var fcfs = new FcfsQueue();
            fcfs.Enqueue(p1);
            fcfs.Enqueue(p2);
            fcfs.Enqueue(p3);
            fcfs.Enqueue(p4);
            fcfs.Enqueue(p5);

            Console.WriteLine(fcfs);
            fcfs.Order();
            Console.WriteLine(fcfs);

            fcfs.Run();
            Console.WriteLine(fcfs.Chart);
            Console.WriteLine(fcfs.TotalRunTime);
            #endregion

            #region SJF
            Console.WriteLine("# SJF");
            var sjf = new SjfQueue();
            sjf.Enqueue(p1);
            sjf.Enqueue(p2);
            sjf.Enqueue(p3);
            sjf.Enqueue(p4);
            sjf.Enqueue(p5);

            Console.WriteLine(sjf);
            sjf.Order();
            Console.WriteLine(sjf);

            sjf.Run();
            Console.WriteLine(sjf.Chart);
            Console.WriteLine(sjf.TotalRunTime);
            #endregion
            */

            #region Round Robin

            Console.WriteLine("# RR");
            var rr = new RoundRobin(10);
            rr.Enqueue(p1);
            rr.Enqueue(p2);
            rr.Enqueue(p3);
            rr.Enqueue(p4);
            rr.Enqueue(p5);

            Console.WriteLine(rr);

            rr.Run();
            Console.WriteLine(rr.Chart);
            Console.WriteLine(rr.TotalRunTime);

            #endregion

            End();
        }

        private static void tahin() {
            Fcfs lq = new Fcfs();
            lq.Enqueue(new ProcessControlBlock {ArrivalTime = 1, Name = "A", BurstTime = 5});
            lq.Enqueue(new ProcessControlBlock {ArrivalTime = 6, Name = "B", BurstTime = 6});
            lq.Enqueue(new ProcessControlBlock {ArrivalTime = 3, Name = "C", BurstTime = 2});
            lq.Enqueue(new ProcessControlBlock {ArrivalTime = 4, Name = "D", BurstTime = 3});
            lq.Enqueue(new ProcessControlBlock {ArrivalTime = 8, Name = "E", BurstTime = 1});
            lq.Enqueue(new ProcessControlBlock {ArrivalTime = 2, Name = "F", BurstTime = 4});

            Console.WriteLine(lq.Display());
            lq.OrderByArrivelTime();
            Console.WriteLine(lq.Display());
            lq.Go();
            Console.WriteLine($"    Total Burst Time : {lq.TotalBurstTime}");
            Console.WriteLine($"  Average Burst Time : {lq.AverageBurstTime()}");
            Console.WriteLine($"Average Waiting Time : {lq.AverageWaitingTime()}");
            End();
        }

        private static void Main() {
            var processStore = ProcessParser.StringToList(File.ReadAllText("Process.txt"));
            RoundRobin rr = new RoundRobin(processStore.QuantumTime);
            foreach (IProcess t in processStore.Processes) {
                rr.Enqueue(t);
            }

            Console.WriteLine(rr);
            rr.Run();
            Console.WriteLine(rr.Chart);
            Console.WriteLine(rr.TotalRunTime);

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