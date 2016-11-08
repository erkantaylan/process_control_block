using System.Collections.Generic;
using Dependencies;

namespace Models {
    public class GanttChart {

        private List<ProcessControlBlock> Processes { get; set; }

        public GanttChart() {
            Processes = new List<ProcessControlBlock>();
        }
        
    }
}