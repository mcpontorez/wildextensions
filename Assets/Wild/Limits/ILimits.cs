namespace Wild.Limits
{
    public interface ILimits<T>
    {
        T Min { get; set; }
        T Max { get; set; }
        T GetRandomValue();
    }
}
