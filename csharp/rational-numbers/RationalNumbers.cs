using System;

public static class RealNumberExtension {
    public static double Expreal(this int realNumber, RationalNumber r)
        => r.Expreal(realNumber);
}

public struct RationalNumber {
    readonly int numerator;
    readonly int denominator;

    public RationalNumber(int numerator, int denominator) {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public override string ToString() {
        return $"{numerator}/{denominator}";
    }

    public RationalNumber Add(RationalNumber r)
        => new RationalNumber(numerator * r.denominator + denominator * r.numerator, denominator * r.denominator).Reduce();

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => r1.Add(r2);

    public RationalNumber Sub(RationalNumber r)
        => new RationalNumber(numerator * r.denominator - denominator * r.numerator, denominator * r.denominator).Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => r1.Sub(r2);

    public RationalNumber Mul(RationalNumber r)
        => new RationalNumber(numerator * r.numerator, denominator * r.denominator).Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => r1.Mul(r2);

    public RationalNumber Div(RationalNumber r)
        => new RationalNumber(numerator * r.denominator, r.numerator * denominator).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => r1.Div(r2);

    public RationalNumber Abs() => new RationalNumber(Math.Abs(numerator), Math.Abs(denominator));

    public RationalNumber Reduce() {
        var abs = Abs();
        var gcd = GCD(abs.numerator, abs.denominator);
        var sign = 1;
        if (denominator < 0) {
            sign = -1;
        }

        return new RationalNumber(numerator * sign / gcd, denominator * sign / gcd);
    }

    public RationalNumber Exprational(int power)
        => new RationalNumber((int)Math.Pow(numerator, power), (int)Math.Pow(denominator, power)).Reduce();

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, numerator / (double)denominator);

    static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}