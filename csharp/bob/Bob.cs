public static class Bob {
    public static string Response(string statement) {
        var guardedStatement = statement.Trim();
        if (guardedStatement == string.Empty) {
            return "Fine. Be that way!";
        }

        var isYelling = IsAllUpper(guardedStatement);
        if (guardedStatement.EndsWith('?')) {
            if (isYelling) {
                return "Calm down, I know what I'm doing!";
            }
            
            return "Sure.";
        }

        if (isYelling) {
            return "Whoa, chill out!";
        }

        return "Whatever.";
    }

    static bool IsAllUpper(string input) {
        var foundLetter = false;
        for (int i = 0; i < input.Length; i++) {
            var thisCharIsLetter = char.IsLetter(input[i]);
            foundLetter |= thisCharIsLetter;
            if (!char.IsUpper(input[i]) && thisCharIsLetter) {
                return false;
            }
        }

        return foundLetter;
    }
}