namespace SpaceBattle.Lib;

public class MovingAdapter : IMoving
{
    private readonly IDictionary<string, object> _dictionary;

    public MovingAdapter(IDictionary<string, object> dictionary)
    {
        _dictionary = dictionary;
    }

    public Vector Position
    {
        get => (Vector)_dictionary[nameof(Position)];
        set => _dictionary[nameof(Position)] = value;
    }

    public Vector Velocity
    {
        get => (Vector)_dictionary[nameof(Velocity)];
        set => _dictionary[nameof(Velocity)] = value;
    }
}