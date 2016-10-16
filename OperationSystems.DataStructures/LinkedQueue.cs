using System.Text;

namespace OperationSystems.DataStructures {

    public class LinkedQueue<T> {

        public Node<T> Front { get; set; }
        public Node<T> Rear { get; set; }


        public void Enqueue(T value) {
            var node = new Node<T>(value);
            if (Rear == null) {
                Front = node;
                Rear = node;
            } else {
                Rear.Next = node;
                Rear = node;
            }
        }

        public Node<T> Dequeue() {
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
                output.Append($"{current.Value.ToString()} ");
                current = current.Next;
            }
            return output.ToString();
        }

        public bool IsQueueEmpty() {
            return Front == null;
        }

    }

    public class Node<T> {

        public Node(T value) {
            Value = value;
        }

        public Node<T> Next { get; set; }

        public T Value { get; set; }

    }

}