using System;

public static class CollatzConjecture {
    public static int Steps(int number) {
        if (number < 1) {
            throw new ArgumentException($"{nameof(number)} must be greater or eqaul to 1");
        }

        var steps = 0;
        while (number != 1) {
            if (IsEven(number)) {
                number /= 2;
            } else {
                number = number * 3 + 1;
            }

            steps++;
        }

        return steps;
    }

    static bool IsEven(int number) => number % 2 == 0;
}