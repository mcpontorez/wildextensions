namespace Wild.GameObjectPool
{
    public interface IPoolObject
    {
        /// <summary>
        /// Вызывать при доставании из пула
        /// </summary>
        void GetFromPool();

        /// <summary>
        /// Использовать для дополнительных изменений перед возвращением в пул. Например, отписка от событий
        /// </summary>
        void PrepareReturnToPool();
    }
}