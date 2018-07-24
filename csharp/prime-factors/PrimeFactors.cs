using System;
using System.Collections.Generic;

public static class PrimeFactors {
    public static int[] Factors(long number) {
        if (number == 1L) {
            return Array.Empty<int>();
        }

        var divisors = new List<int>();
        do {
            for (int i = 2; i <= number; i++) {
                if (number % i == 0) {
                    divisors.Add(i);
                    number /= i;
                    break;
                }
            }
        } while (number != 1);

        return divisors.ToArray();
    }
}