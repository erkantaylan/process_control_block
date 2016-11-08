using System;
using System.Collections.Generic;
using Dependencies;
using Models;

namespace Library.Parser {
    public class ProcessParser {
        public static ProcessStore StringToList(string text) {
            Validation(text);

            var ps = new ProcessStore();
            var lines = SplitTrimmed(text, new[] {'\n'});

            ParseQuantumTime(lines, ps);
            ParseProcesses(lines, ps);

            return ps;
        }

        private static void ParseProcesses(string[] lines, ProcessStore ps) {
            ps.Processes = new List<IProcess>(lines.Length);
            for (int i = 1; i < lines.Length; i++) {
                var line = lines[i];
                IProcess process = ParseToProcess(line);
                ps.Processes.Add(process);
            }
        }

        private static IProcess ParseToProcess(string line) {
            var splitted = SplitTrimmed(line, new[] {'\t'});
            foreach (string t in splitted) {
                Validation(t);
            }
            return new ProcessControlBlock {
                Name        = splitted[0],
                BurstTime   = Convert.ToInt32(splitted[1]),
                Priority    = Convert.ToInt32(splitted[2]),
                ArrivalTime = Convert.ToInt32(splitted[3]),
            };
        }

        private static void Validation(string text) {
            if (string.IsNullOrWhiteSpace(text)) {
                throw new Exception($"String bos veya Hatali : {text}");
            }
        }

        private static void ParseQuantumTime(string[] lines, ProcessStore ps) {
            int quantumTime;
            if (int.TryParse(lines[0], out quantumTime)) {
                ps.QuantumTime = quantumTime;
            }
            else {
                throw new Exception($"Quantum Time Okunamadi {lines[0]}");
            }
        }

        private static string[] SplitTrimmed(string text, char[] seperators) {
            var lines = text.Trim().Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++) {
                lines[i] = lines[i].Trim();
            }
            return lines;
        }
    }
}