namespace SpaceBattle.Lib;

public class RotateAdapter : IRotate
{
    private readonly IDictionary<string, object> _dictionary;

    public RotateAdapter(IDictionary<string, object> dictionary)
    {
        _dictionary = dictionary;
    }

    public Angle PositionAngle
    {
        get => (Angle)_dictionary[nameof(PositionAngle)];
        set => _dictionary[nameof(PositionAngle)] = value;
    }

    public Angle VelocityAngle
    {
        get => (Angle)_dictionary[nameof(VelocityAngle)];
        set => _dictionary[nameof(VelocityAngle)] = value;
    }
}
