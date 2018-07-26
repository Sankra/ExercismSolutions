using System.Text;
using BenchmarkDotNet.Attributes;

[RankColumn, MemoryDiagnoser]
public class Raindrops {
    [Params(0, 3, 5, 7, 15, 21, 105)]
    public int Number;

    [Benchmark]
    public string Convert() {
        var raindropSpeak = "";
        if (Number % 3 == 0) {
            raindropSpeak += "Pling";
        }

        if (Number % 5 == 0) {
            raindropSpeak += "Plang";
        }

        if (Number % 7 == 0) {
            raindropSpeak += "Plong";
        }

        return raindropSpeak.Length == 0 ? Number.ToString() : raindropSpeak;
    }

    [Benchmark]
    public string StringBuilderConvert() {
        var raindropSpeak = new StringBuilder(15);
        if (Number % 3 == 0) {
            raindropSpeak.Append("Pling");
        }

        if (Number % 5 == 0) {
            raindropSpeak.Append("Plang");
        }

        if (Number % 7 == 0) {
            raindropSpeak.Append("Plong");
        }

        return raindropSpeak.Length == 0 ? Number.ToString() : raindropSpeak.ToString();
    }
}