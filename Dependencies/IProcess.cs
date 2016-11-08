using System.Security.Cryptography.X509Certificates;

namespace Dependencies {
    public interface IProcess {
        string Name { get; set; }
        ProcessStates ProcessState { get; set; }

        //tamamlanmasi icin gereken toplam calisma zamani
        int BurstTime { get; set; }
        int ArrivalTime { get; set; }
        //calisma zamani (burst timea esit oldugunda tamamlanmis olur)
        int RunTime { get; set; }
        int WaitingTime { get; set; }
        int Priority { get; set; }
    }

}