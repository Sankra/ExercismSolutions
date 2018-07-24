using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples {
    public static int Sum(IEnumerable<int> multiples, int max)
        => Enumerable.Range(1, max - 1).Where(num => multiples.Any(divisor => num % divisor == 0)).Sum();
}