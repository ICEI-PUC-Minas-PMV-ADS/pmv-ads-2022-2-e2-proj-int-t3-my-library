using System.ComponentModel.DataAnnotations;

public class MaxValueAttribute : ValidationAttribute
{
    private readonly int _maxValue;

    public MaxValueAttribute(int maxValue)
    {
        _maxValue = maxValue;
    }

    public override bool IsValid(object value)
    {
        return (int)value <= _maxValue;
    }
}
public class MinValueAttribute : ValidationAttribute
{
    private readonly int _maxValue;

    public MinValueAttribute(int maxValue)
    {
        _maxValue = maxValue;
    }

    public override bool IsValid(object value)
    {
        return (int)value >= _maxValue;
    }
}