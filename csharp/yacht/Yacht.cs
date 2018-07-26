using System.Linq;

public enum YachtCategory {
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame {
    public static int Score(int[] dice, YachtCategory category) {
        var occurences = dice.GroupBy(d => d).ToDictionary(group => group.Key, group => group.Count());
        switch (category) {
            case YachtCategory.Ones:
            case YachtCategory.Twos:
            case YachtCategory.Threes:
            case YachtCategory.Fours:
            case YachtCategory.Fives:
            case YachtCategory.Sixes:
                return dice.Where(d => d == (int)category).Sum();
            case YachtCategory.FullHouse when
                              occurences.Keys.Count == 2
                              && occurences.Values.All(o => o == 2 || o == 3):
                return dice.Sum();
            case YachtCategory.FourOfAKind when
                              occurences.Values.Any(o => o >= 4):
                return occurences.Single(kvp => kvp.Value >= 4).Key * 4;
            case YachtCategory.LittleStraight when
                              occurences.Values.All(o => o == 1)
                              && occurences.ContainsKey(1)
                              && occurences.ContainsKey(5):
                return 30;
            case YachtCategory.BigStraight when
                              occurences.Values.All(o => o == 1)
                              && occurences.ContainsKey(2)
                              && occurences.ContainsKey(6):
                return 30;
            case YachtCategory.Choice:
                return dice.Sum();
            case YachtCategory.Yacht when
                              dice.All(o => o == dice[0]):
                return 50;
            default:
                return 0;
        }
    }
}

