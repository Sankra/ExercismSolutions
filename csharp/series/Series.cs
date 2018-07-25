using System;
using System.Linq;

public static class Series {
    public static string[] Slices(string numbers, int sliceLength) {
        if (string.IsNullOrEmpty(numbers)) {
            throw new ArgumentException($"{nameof(numbers)} must contain at least 1 digit.", nameof(numbers));
        }

        if (sliceLength <= 0) {
            throw new ArgumentException($"{nameof(sliceLength)} must be of size 1 or larger.", nameof(sliceLength));
        }

        if (sliceLength > numbers.Length) {
            throw new ArgumentException($"{nameof(sliceLength)} cannot be larger than the number of digits in {nameof(numbers)}.", nameof(sliceLength));
        }

        var numberOfPossibleSlices = numbers.Length - sliceLength + 1;
        var slices = new string[numberOfPossibleSlices];
        var digits = numbers.ToCharArray();
        for (int i = 0; i < numberOfPossibleSlices; i++) {
            slices[i] = new string(digits.Skip(i).Take(sliceLength).ToArray());
        }

        return slices;
    }
}