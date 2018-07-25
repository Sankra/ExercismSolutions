using System;
using System.Collections.Generic;

public static class SecretHandshake {
    public static string[] Commands(int commandValue) {
        var commands = new List<string>();
        bool reverse = true;
        var availableCommands = new[] {
            new Command(1, () => commands.Add("wink")),
            new Command(2, () => commands.Add("double blink")),
            new Command(4, () => commands.Add("close your eyes")),
            new Command(8, () => commands.Add("jump")),
            new Command(16, () =>  reverse = false)
        };

        for (int i = availableCommands.Length - 1; i >= 0; i--) {
            if (commandValue - availableCommands[i].Value >= 0) {
                commandValue -= availableCommands[i].Value;
                availableCommands[i].Action();
            }
        }

        if (reverse) {
            commands.Reverse();
        }

        return commands.ToArray();
    }

    struct Command {
        public Command(int value, Action action) {
            Value = value;
            Action = action;
        }

        public int Value { get; }
        public Action Action { get; }
    }
}
