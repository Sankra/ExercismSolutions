using System.Linq;

public enum Classification {
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers {
    public static Classification Classify(int number) {
        var divisors = GetDivisors(number);
        var sumOfDivisors = divisors.Sum();
        if (sumOfDivisors == number) {
            return Classification.Perfect;
        }

        if (sumOfDivisors > number) {
            return Classification.Abundant;
        }

        return Classification.Deficient;
    }

    static int[] GetDivisors(int number)
        => Enumerable.Range(1, number - 1).Where(n => number % n == 0).ToArray();
}