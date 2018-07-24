using System;
using System.Collections.Generic;

public class Robot {
    static readonly Random random;
    static readonly HashSet<string> names;

    bool firstBoot;
    string name;

    static Robot() {
        random = new Random();
        names = new HashSet<string>();
    }

    public Robot() {
        firstBoot = true;
    }

    public string Name {
        get {
            if (firstBoot) {
                name = GetName();
                firstBoot = false;
            }

            return name;
        }
    }

    public void Reset() {
        firstBoot = true;
    }

    string GetName() {
        string potentialName;
        do {
            potentialName = GenerateName();
        } while (IsNameAlreadyUsed(potentialName));
        return potentialName;
    }

    string GenerateName() 
        => $"{GetRandomLetter()}{GetRandomLetter()}{GetRandomNumberFromOneToTen()}{GetRandomNumberFromOneToTen()}{GetRandomNumberFromOneToTen()}".ToUpper();

    bool IsNameAlreadyUsed(string potentialName) => names.Contains(potentialName);

    char GetRandomLetter() {
        int alphabetIndex = random.Next(1, 27);
        char letter = (char)('a' + alphabetIndex);
        return letter;
    }

    int GetRandomNumberFromOneToTen() => random.Next(1, 11);
}