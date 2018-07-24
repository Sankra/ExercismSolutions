using System.Linq;

public static class IsbnVerifier {
    public static bool IsValid(string number) {
        number = number.Replace("-", "");
        if (number.Length != 10) {
            return false;
        }

        var chars = number.ToCharArray();
        if (!chars.Take(9).All(c => char.IsDigit(c))) {
            return false;
        }

        if (!char.IsDigit(chars[9]) && chars[9] != 'X') {
            return false;
        }

        var digits = chars.Select(c => c == 'X' ? 10 : (int)char.GetNumericValue(c)).ToArray();
        return (digits[0] * 10
                + digits[1] * 9
                + digits[2] * 8
                + digits[3] * 7
                + digits[4] * 6
                + digits[5] * 5
                + digits[6] * 4
                + digits[7] * 3
                + digits[8] * 2
                + digits[9] * 1) % 11 == 0;
    }
}