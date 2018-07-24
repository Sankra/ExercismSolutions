using System;
using System.Linq;

public static class Triangle {
    public static bool IsScalene(double side1, double side2, double side3) 
        => new ActualTriangle(side1, side2, side3).Kind == TriagleKind.Scalene;

    public static bool IsIsosceles(double side1, double side2, double side3) {
        var kind = new ActualTriangle(side1, side2, side3).Kind;
        return kind == TriagleKind.Equilateral || kind == TriagleKind.Isosceles;
    }
        
    public static bool IsEquilateral(double side1, double side2, double side3) 
        => new ActualTriangle(side1, side2, side3).Kind == TriagleKind.Equilateral;

    class ActualTriangle {
        readonly TriagleKind triagleKind;

        public ActualTriangle(double side1, double side2, double side3) {
            var sides = new[] { side1, side2, side3 };
            triagleKind = FindKind(sides);
        }

        public TriagleKind Kind => triagleKind;

        TriagleKind FindKind(double[] sides) {
            if (sides.Any(side => side <= 0)) {
                return TriagleKind.Invalid;
            }

            var longestSide = sides.Max();
            if (longestSide > sides.Sum() - longestSide) {
                return TriagleKind.Invalid;
            }

            if (sides.All(side => side.IsApproximatelyEqualTo(sides[0]))) {
                return TriagleKind.Equilateral;    
            }

            if (sides.Distinct().Count() == sides.Length) {
                return TriagleKind.Scalene;
            }

            return TriagleKind.Isosceles;
        }
    }

    enum TriagleKind {
        Equilateral,
        Isosceles,
        Scalene,
        Invalid
    }
}

public static class DoubleExtensions {
    public static bool IsApproximatelyEqualTo(this double initialValue, double value)
        => Math.Abs(initialValue - value) < 0.00001D;    
}
