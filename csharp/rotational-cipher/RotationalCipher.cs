using System.Collections.Generic;
using System.Linq;

public static class RotationalCipher {
    static readonly List<char> alphabet;

    static RotationalCipher() {
        alphabet = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
    }

    public static string Rotate(string text, int shiftKey) {
        var shiftedText = new char[text.Length];
        for (int i = 0; i < text.Length; i++) {
            ShiftCharacter(i);
        }

        return new string(shiftedText);

        void ShiftCharacter(int i) {
            if (char.IsLetter(text[i])) {
                var j = GetNewIndex(text[i]);
                shiftedText[i] = char.IsUpper(text[i]) ? char.ToUpper(alphabet[j]) : alphabet[j];
            } else {
                shiftedText[i] = text[i];
            }
        }

        int GetNewIndex(char c) {
            var i = alphabet.IndexOf(char.ToLower(c));
            var j = i + shiftKey;
            if (j > alphabet.Count - 1) {
                j -= alphabet.Count;
            }

            return j;
        }
    }
}