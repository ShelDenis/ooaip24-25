namespace SpaceBattle.Lib;

public class Angle
{
    int numerator;
    int denominator;

    public Angle(int n, int d)
    {
        numerator = n % d;
        denominator = d;
    }

    public int Numerator
    {
        get => numerator % denominator;
    }

    public int Denominator
    {
        get => denominator;
    }

    public static Angle operator +(Angle a1, Angle a2)
    {
        int new_num = a1.Numerator + a2.Numerator;
        new_num %= a1.Denominator;
        return new Angle(new_num, a1.Denominator);
    }

    public double Sin()
    {
        double n = numerator;
        double d = denominator;
        return Math.Sin(n / d * Math.PI * 2);
    }

    public double Cos()
    {
        double n = numerator;
        double d = denominator;
        return Math.Cos(n / d * Math.PI * 2);
    }

    public static bool operator ==(Angle a1, Angle a2)
    {
        return a1.GetHashCode() == a2.GetHashCode();
    }

    public static bool operator !=(Angle a1, Angle a2)
    {
        return a1.GetHashCode() != a2.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj != null && obj is Angle angle && (Numerator % Denominator) == (angle.Numerator % angle.Denominator);
    }

    public override int GetHashCode()
    {
        return (numerator % denominator).GetHashCode();
    }
}