public static class Raindrops {
    public static string Convert(int number) {
        var raindropSpeak = "";
        if (number % 3 == 0) {
            raindropSpeak += "Pling";
        }

        if (number % 5 == 0) {
            raindropSpeak += "Plang";
        }

        if (number % 7 == 0) {
            raindropSpeak += "Plong";
        }

        return raindropSpeak.Length == 0 ? number.ToString() : raindropSpeak;
    }
}