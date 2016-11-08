using System;
using System.Text;

namespace OperationSystems.DataStructures {
    public class FcfsQueue : LinkedQueue {
        private int totalRunTime;
        private StringBuilder output { get; set; }
        private StringBuilder ganttChart = new StringBuilder("Current Time    : 0\n");

        public FcfsQueue() {
            InitializeOutput();
        }

        public int TotalRunTime => totalRunTime;

        public StringBuilder Chart {
            get { return ganttChart; }
        }

        public void Run() {
            while (!IsQueueEmpty()) {
                var current = Dequeue();
                current.Value.WaitingTime += totalRunTime;
                totalRunTime += current.Value.BurstTime;
                current.Value.RunTime = current.Value.BurstTime;

                ganttChart.AppendLine($"Current Process : {current.Value.Name}");
                ganttChart.AppendLine($"Current Time    : {totalRunTime}");
            }
        }

        private void InitializeOutput() {
            output = new StringBuilder();
            output.AppendLine("PROCESS NAME | ARRIVAL TIME | BURST TIME | FINISH TIME | WAITING TIME");
        }



    }

    public class Fcfs : LQueue {
        public int TotalBurstTime;
        public int TotalWaitingTime;
        public int DoneProcessCount;

        public void Go() {
            while (!IsQueueEmpty()) {
                var current = Dequeue();
                current.Value.WaitingTime += TotalBurstTime;
                TotalWaitingTime += current.Value.WaitingTime;
                TotalBurstTime += current.Value.BurstTime;
                DoneProcessCount += 1;

                Console.WriteLine($"Current Process : {current.Value.Name}");
                Console.WriteLine($"Waiting Time    : {current.Value.WaitingTime}\n");
            }
        }

        public double AverageWaitingTime() {
            return (double) TotalWaitingTime / DoneProcessCount;
        }

        public double AverageBurstTime() {
            return (double) TotalBurstTime / DoneProcessCount;
        }

    }

}