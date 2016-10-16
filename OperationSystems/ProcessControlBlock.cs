/*file:///E:/_LESSONS/_isletim_sistemleri/slides/ch3.pdf
 * page 9
**/
using System.Collections.Generic;

namespace OperationSystems {

    public class ProcessControlBlock {

        //Process state - running waiting etc
        public ProcessStates ProcessState { get; set; }

        //program counter - location of instruction to next execute
        public ProgramCounter ProgramCounter { get; set; }

        // cpu registers - contents of all processcentric registers
        public List<Register> Registers { get; set; }

        //cpu scheduling information - proirities, scheduling queue pointers

        //accounting  information - cpu used, clock time elapsed since start, time limits

        // i/o status information - i/o devices allocated to process, list of open files

    }

    public enum ProcessStates {
        Newbie,
        Ready,
        Running,
        Waiting,
        Terminated,
    }

    public class ProgramCounter {

        

    }

    public class Register { }

}