using System;
using System.Linq;
using System.Collections.Generic;

public static class WordCount {
    public static IDictionary<string, int> CountWords(string phrase) {
        var wordCount = new Dictionary<string, int>();
        var words = phrase
            .ToLower()
            .Split(new[] { " ", ",", ",\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => word.Trim('\''))
            .Select(word => new string(word
                                       .ToCharArray()
                                       .Where(c => char.IsLetterOrDigit(c) || c == '\'')
                                       .ToArray()));
        foreach (var word in words) {
            wordCount.TryGetValue(word, out int count);
            wordCount[word] = count + 1;
        }

        return wordCount;
    }
}