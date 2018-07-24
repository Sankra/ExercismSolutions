using System;

public class SpaceAge
{
    readonly long seconds;

    public SpaceAge(long seconds)
    {
        this.seconds = seconds;
    }

    public double OnEarth() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / 365.25D, 2);

    public double OnMercury() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 0.2408467D), 2);

    public double OnVenus() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 0.61519726D), 2);

    public double OnMars() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 1.8808158D), 2);

    public double OnJupiter() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 11.862615D), 2);

    public double OnSaturn() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 29.447498D), 2);

    public double OnUranus() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 84.016846D), 2);

    public double OnNeptune() => Math.Round(TimeSpan.FromSeconds(seconds).TotalDays / (365.25 * 164.79132D), 2);
}