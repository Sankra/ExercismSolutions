using System.Collections.Generic;
using System.Linq;

public class Triplet {
    readonly int[] triplet;

    public Triplet(int a, int b, int c) {
        triplet = new[] { a, b, c };
    }

    public int Sum() => triplet.Sum();

    public int Product() => triplet.Aggregate(1, (product, val) => product * val);

    public bool IsPythagorean() => triplet[0] * triplet[0] + triplet[1] * triplet[1] == triplet[2] * triplet[2]; 

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0) {
        var triplets = new List<Triplet>();

        for (int a = minFactor; a <= maxFactor - 2; a++) {
            for (int b = a + 1; b <= maxFactor - 1; b++) {
                for (int c = b + 1; c <= maxFactor; c++) {
                    var triplet = new Triplet(a, b, c);
                    if (triplet.IsPythagorean() && (sum == 0 || triplet.Sum() == sum)) {
                        triplets.Add(triplet);
                    }
                }
            }
        }

        return triplets;
    }
}