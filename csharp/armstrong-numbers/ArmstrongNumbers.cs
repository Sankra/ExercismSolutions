using System;
using System.Linq;

public static class ArmstrongNumbers {
    public static bool IsArmstrongNumber(int number) {
        var digits = number
            .ToString()
            .ToCharArray()
            .Select(c => (int)char.GetNumericValue(c))
            .ToArray();
        return digits.Sum(d => (int)Math.Pow(d, digits.Length)) == number;
    }
}