public class Angle : IConvertible
{
    int numerator;
    int denominator;

    public Angle(int n, int d)
    {
        numerator = n;
        denominator = d;
    }

    public int Numerator
    {
        get => numerator;
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

    public double ToDouble(IFormatProvider? provider)
    {
        return (double)numerator / denominator * Math.PI / 180;
    }

    public static bool operator ==(Angle a1, Angle a2)
    {
        return a1.numerator == a2.numerator;
    }

    public static bool operator !=(Angle a1, Angle a2)
    {
        return a1.numerator != a2.numerator;
    }

    public override bool Equals(object? obj)
    {
        return obj != null && obj is Angle angle && Numerator == angle.Numerator;
    }

    public override int GetHashCode()
    {
        return numerator.GetHashCode();
    }

    public TypeCode GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public bool ToBoolean(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public byte ToByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public char ToChar(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public decimal ToDecimal(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public short ToInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public int ToInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public long ToInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public sbyte ToSByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public float ToSingle(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public uint ToUInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public ulong ToUInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

}