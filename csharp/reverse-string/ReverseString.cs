using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var chars = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            chars[input.Length - i - 1] = input[i];
        }

        return new string(chars);
    }
}