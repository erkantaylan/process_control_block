using System.Text;
using Dependencies;
using Models;

namespace OperationSystems.DataStructures {
    public class RoundRobin : LinkedQueue {

        private int totalRunTime;
        private int quantumTime;
        private StringBuilder ganttChart = new StringBuilder();

        public RoundRobin(int quantumTime) {
            this.quantumTime = quantumTime;
        }

        public int TotalRunTime => totalRunTime;

        public StringBuilder Chart {
            get { return ganttChart; }
        }

        public void Run() {
            while (!IsQueueEmpty()) {
                var current = Dequeue();
                ganttChart.AppendLine($"Current Time    : {totalRunTime}");
                ganttChart.AppendLine($"Current Process : {current.Value.Name}");
                ganttChart.AppendLine($"Process Burst Time Before Run : {current.Value.BurstTime}");

                Run(current);

                ganttChart.AppendLine($"Process Burst Time After Run : {current.Value.BurstTime}");
                ganttChart.AppendLine($"Current Time    : {totalRunTime}\n");
            }
        }

        private void Run(Node<IProcess> current) {
            if (BurstTimeBiggerThanQuantum(current)) {
                current.Value.BurstTime -= quantumTime;
                totalRunTime += quantumTime;
                if (ProcessNeedToWorkMore(current)) {
                    Enqueue(current.Value);
                }
            }
            else if (BurstTimeNotBiggerThanQuantumButNeedToWork(current)) {
                totalRunTime += current.Value.BurstTime;
                current.Value.BurstTime = 0;
            }
        }

        private bool BurstTimeNotBiggerThanQuantumButNeedToWork(Node<IProcess> current) {
            return current.Value.BurstTime > 0;
        }

        private static bool ProcessNeedToWorkMore(Node<IProcess> current) {
            return current.Value.BurstTime > 0;
        }

        private bool BurstTimeBiggerThanQuantum(Node<IProcess> current) {
            return current.Value.BurstTime >= quantumTime;
        }
    }
}