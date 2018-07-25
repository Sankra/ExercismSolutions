using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram {
    readonly string lowerCaseWord;
    readonly char[] letters;

    public Anagram(string baseWord) {
        lowerCaseWord = baseWord.ToLower();
        letters = baseWord.ToLower().ToCharArray();
    }

    public string[] Anagrams(string[] potentialMatches) {
        return potentialMatches.Where(IsAnagram).ToArray();

        bool IsAnagram(string potentialAnagram) {
            if (potentialAnagram.Length != letters.Length) {
                return false;
            }

            potentialAnagram = potentialAnagram.ToLower();
            if (lowerCaseWord == potentialAnagram) {
                return false;
            }

            var remainingLetters = new List<char>(potentialAnagram.ToCharArray());
            foreach (var letter in letters) {
                var i = remainingLetters.IndexOf(letter);
                if (i == -1) {
                    break;
                }

                remainingLetters.RemoveAt(i);
            }

            if (remainingLetters.Count == 0) {
                return true;
            }

            return false;
        }
    }
}