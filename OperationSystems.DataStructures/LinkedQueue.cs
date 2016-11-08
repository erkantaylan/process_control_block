using System;
using System.Text;
using Dependencies;
using Models;

namespace OperationSystems.DataStructures {

    public class LinkedQueue {

        public Node<IProcess> Front { get; set; }
        public Node<IProcess> Rear { get; set; }

        public void Enqueue(IProcess value) {
            var node = new Node<IProcess>(value);
            if (Rear == null) {
                Front = node;
                Rear = node;
            }
            else {
                Rear.Next = node;
                Rear = node;
            }
        }

        public Node<IProcess> Dequeue() {
            if (Front == null) {
                return null;
            }
            var target = Front;
            Front = Front.Next;
            return target;
        }

        public override string ToString() {
            var output = new StringBuilder();
            var current = Front;
            while (current != null) {
                output.Append($"[n:{current.Value.Name}|b.t:{current.Value.BurstTime}|a.t:{current.Value.ArrivalTime}] ");
                current = current.Next;
            }
            output.AppendLine();
            return output.ToString();
        }

        public bool IsQueueEmpty() {
            return Front == null;
        }

        public virtual void Order() {
            var current1 = Front;
            while (current1 != null) {
                var min = current1;
                var current2 = current1;
                while (current2 != null) {
                    if (min.CompareTo(current2.Value) == 1) {
                        min = current2;
                    }
                    current2 = current2.Next;
                }
                SwapNodeValues(current1, min);
                current1 = current1.Next;
            }
        }

        public void SwapNodeValues(Node<IProcess> current1, Node<IProcess> min) {
            var temp = current1.Value;
            current1.Value = min.Value;
            min.Value = temp;
        }

    }

    public class Node<T> : IComparable {

        public Node(T value) {
            Value = value;
        }

        public Node<T> Next { get; set; }

        public T Value { get; set; }

        public int CompareTo(object value) {
            if (typeof(T) == typeof(IProcess)) {
                if (((IProcess)Value).ArrivalTime > ((IProcess)value).ArrivalTime) {
                    return 1;
                }
                if (((IProcess)Value).ArrivalTime < ((IProcess)value).ArrivalTime) {
                    return -1;
                }
                return 0;
            }
            throw new Exception($"Degerler karsilastirilamadi. type:{typeof(T)}, Current Value:{Value}, CompareTo: {value}");
        }
    }

    public class Node {
        public IProcess Value { get; set; }

        public Node Next { get; set; }

        public Node(IProcess value) {
            Value = value;
        }
    }

    public class LQueue {
        public Node Front { get; set; }
        public Node Rear { get; set; }

        public void Enqueue(IProcess value) {
            var node = new Node(value);
            if (Rear == null) {
                Front = node;
                Rear = node;
            }
            else {
                Rear.Next = node;
                Rear = node;
            }
        }

        public Node Dequeue() {
            if (Front == null) {
                return null;
            }
            Node target = Front;
            Front = Front.Next;
            return target;
        }

        public bool IsQueueEmpty() {
            return Front == null;
        }

        public void OrderByArrivelTime() {
            var current1 = Front;
            while (current1 != Rear) {
                var min = current1;
                var current2 = current1;
                while (current2 != Rear) {
                    if (min.Value.ArrivalTime > current2.Value.ArrivalTime) {
                        min = current2;
                    }
                    current2 = current2.Next;
                }
                Swap(current1, min);

                current1 = current1.Next;
            }
        }

        private static void Swap(Node current1, Node min) {
            var temp = current1.Value;
            current1.Value = min.Value;
            min.Value = temp;
        }

        public string Display() {
            var output = new StringBuilder();
            var current = Front;
            while (current != null) {
                output.Append($"{current.Value.Name} ");
                current = current.Next;
            }
            output.AppendLine();
            return output.ToString();
        }

    }

}