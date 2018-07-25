using System;
using System.Linq;

public class PhoneNumber {
    public static string Clean(string phoneNumber) {
        var digits = new string(phoneNumber.ToCharArray().Where(c => char.IsNumber(c)).ToArray());
        if (digits.Length == 11) {
            if (digits[0] != '1') {
                throw new ArgumentException($"Country code must be 1.");
            }

            digits = digits.Remove(0, 1);
        }

        if (digits.Length != 10) {
            throw new ArgumentException($"Number must be 10 digits.");
        }

        const int AreaCodeIndex = 0;
        if (digits[AreaCodeIndex] == '0' || digits[AreaCodeIndex] == '1') {
            throw new ArgumentException($"Area code cannot start with a {digits[AreaCodeIndex]}.");
        }

        const int ExchangeCodeIndex = 3;
        if (digits[ExchangeCodeIndex] == '0' || digits[ExchangeCodeIndex] == '1') {
            throw new ArgumentException($"Exchange code cannot start with a {digits[ExchangeCodeIndex]}.");
        }

        return digits;
    }
}