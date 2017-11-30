
namespace Wild.Coroutines
{
    public interface ICancellationToken
    {
        bool Canceled { get; }

        void Cancel();
    }
}
