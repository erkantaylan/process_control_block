namespace OperationSystems.DataStructures {
    public class SjfQueue : FcfsQueue {

        public override void Order() {
            var current1 = Front;
            while (current1 != null) {
                var min = current1;
                var current2 = current1;
                while (current2 != null) {
                    if (min.Value.BurstTime > current2.Value.BurstTime) {
                        min = current2;
                    }
                    current2 = current2.Next;
                }
                SwapNodeValues(current1, min);
                current1 = current1.Next;
            }
        }

    }
}