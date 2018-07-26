using System;
using BenchmarkDotNet.Running;

namespace Benchmark {
    class Program {
        static void Main() {
            var summary = BenchmarkRunner.Run<Raindrops>();
        }
    }
}
