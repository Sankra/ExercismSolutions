using System.Linq;

public static class TwelveDays {
    const string BaseVerse = "On the {0} day of Christmas my true love gave to me,{1}.";

    static readonly VersePart[] verseParts;

    static TwelveDays() {
        verseParts = new[] {
            new VersePart("first", " a Partridge in a Pear Tree"),
            new VersePart("second", " two Turtle Doves"),
            new VersePart("third", " three French Hens"),
            new VersePart("fourth", " four Calling Birds"),
            new VersePart("fifth", " five Gold Rings"),
            new VersePart("sixth", " six Geese-a-Laying"),
            new VersePart("seventh", " seven Swans-a-Swimming"),
            new VersePart("eighth", " eight Maids-a-Milking"),
            new VersePart("ninth", " nine Ladies Dancing"),
            new VersePart("tenth", " ten Lords-a-Leaping"),
            new VersePart("eleventh", " eleven Pipers Piping"),
            new VersePart("twelfth", " twelve Drummers Drumming"),
        };
    }

    public static string Recite(int verseNumber) {
        var gifts = string.Join(',', verseParts.Take(verseNumber).Reverse().Select(v => v.Gift));
        if (verseNumber > 1) {
            var indexOfLastComma = gifts.LastIndexOf(',');
            gifts = gifts.Insert(indexOfLastComma + 1, " and");
        }

        return string.Format(BaseVerse, verseParts[verseNumber - 1].NumberLiteral, gifts);
    }

    public static string Recite(int startVerse, int endVerse)
        => string.Join('\n', Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(i => Recite(i)));

    public struct VersePart {
        public VersePart(string numberLiteral, string gift) {
            NumberLiteral = numberLiteral;
            Gift = gift;
        }

        public string NumberLiteral { get; }
        public string Gift { get; }
    }
}