using System.Collections.Generic;
using Dependencies;

namespace Models {
    public class ProcessStore {
        public int QuantumTime { get; set; }
        public List<IProcess> Processes { get; set; }
    }
}