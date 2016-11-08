/*file:///E:/_LESSONS/_isletim_sistemleri/slides/ch3.pdf
 * page 9
**/

using System.Collections.Generic;
using Dependencies;

namespace Models {

    public class ProcessControlBlock : IProcess {
        private int runTime;

        //Process state - running waiting etc
        public string Name { get; set; }
        public ProcessStates ProcessState { get; set; }
        public int BurstTime { get; set; }
        public int ArrivalTime { get; set; }

        public int RunTime {
            get { return runTime; }
            set {
                if (value >= BurstTime) {
                    ProcessState = ProcessStates.Terminated;
                }
                runTime = value;
            }
        }

        public int WaitingTime { get; set; }
        public int Priority { get; set; }

        public ProcessControlBlock() {
            ProcessState = ProcessStates.Newbie;
        }

        //program counter - location of instruction to next execute
        //public ProgramCounter ProgramCounter { get; set; }

        // cpu registers - contents of all processcentric registers
        //public List<Register> Registers { get; set; }

        //cpu scheduling information - proirities, scheduling queue pointers

        //accounting  information - cpu used, clock time elapsed since start, time limits

        // i/o status information - i/o devices allocated to process, list of open files

    }

 

    public class ProgramCounter {

        

    }

    public class Register { }

}