using System;
using System.Collections.Generic;

public class BinarySearch {
    readonly List<int> input;

    public BinarySearch(int[] input) {
        this.input = new List<int>(input);
        this.input.Sort();
    }

    public int Find(int value) {
        var left = 0;
        var right = input.Count - 1;
        while (left <= right) {
            var center = (int)Math.Floor((left + right) / 2D);
            if (input[center] < value) {
                left = center + 1;
            } else if (input[center] > value) {
                right = center - 1;
            } else {
                return center;
            }
        }

        return -1;
    }
}