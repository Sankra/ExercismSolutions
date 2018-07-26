using System.Collections.Generic;
using System.Linq;

public static class BracketPush {
    public static bool IsPaired(string input) {
        if (string.IsNullOrEmpty(input)) {
            return true;
        }

        var leftSide = new Queue<char>();
        var rightSide = new Stack<char>();

        char? lastLeft = null;
        for (int i = 0; i < input.Length; i++) {
            if (IsLeftSideCharacter(input[i])) {
                if (lastLeft.HasValue) {
                    leftSide.Enqueue(lastLeft.Value);
                }

                lastLeft = input[i];
            } else if (IsRightSideCharacter(input[i])) {
                if (lastLeft.HasValue && IsMatching(lastLeft.Value, input[i])) {
                    lastLeft = null;
                    continue;
                }

                if (leftSide.Count > 0) {
                    rightSide.Push(input[i]);
                } else {
                    return false;
                }
            }
        }

        if (lastLeft.HasValue) {
            leftSide.Enqueue(lastLeft.Value);
        }

        return leftSide.Count == rightSide.Count
                       && leftSide.All(l => IsMatching(l, rightSide.Pop()));
    }

    static bool IsLeftSideCharacter(char c) => c == '[' || c == '{' || c == '(';
    static bool IsRightSideCharacter(char c) => c == ']' || c == '}' || c == ')';

    static bool IsMatching(char first, char match) {
        switch (first) {
            case '[':
                return match == ']';
            case '{':
                return match == '}';
            case '(':
                return match == ')';
            default:
                return false;
        }
    }
}
