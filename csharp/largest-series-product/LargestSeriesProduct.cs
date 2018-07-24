using System;
using System.Linq;

public static class LargestSeriesProduct {
    public static long GetLargestProduct(string digits, int span) {
        if (span == 0) {
            return 1L;
        }

        if (span < 1 || span > digits.Length) {
            throw new ArgumentException();
        }

        var numbers = digits.ToCharArray().Select(ConvertToInt).ToArray();
        var largetsProduct = 0L;
        for (int j = 0; j < numbers.Length - span + 1; j++) {
            var product = numbers.Skip(j).Take(span).Aggregate(1L, (p, value) => p * value);
            if (product > largetsProduct) {
                largetsProduct = product;
            }
        }

        return largetsProduct;
    }

    static int ConvertToInt(char c) {
        if (!char.IsDigit(c)) {
            throw new ArgumentException();
        }

        return (int)char.GetNumericValue(c);
    }
}