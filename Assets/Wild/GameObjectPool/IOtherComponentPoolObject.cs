namespace Wild.GameObjectPool
{
    public interface IOtherComponentPoolObject : IPoolObject
    {
        /// <summary>
        /// Использовать для инициализации
        /// </summary>
        void Initialize(PoolObject poolObject);
    }
}