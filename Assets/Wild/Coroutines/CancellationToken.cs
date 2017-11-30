
namespace Wild.Coroutines
{
    public sealed class CancellationToken : ICancellationToken
    {
        public bool Canceled { get; private set; } = false;

        public void Cancel() => Canceled = true;
    }
}
