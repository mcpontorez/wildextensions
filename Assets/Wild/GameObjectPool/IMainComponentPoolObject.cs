namespace Wild.GameObjectPool
{
    public interface IMainComponentPoolObject : IPoolObject
    {
        ObjectPool CurrentPool { get; }

        bool InPool { get; }

        /// <summary>
        /// Использовать для инициализации, получения ссылок на другие компоненты игрового объекта и их инициализации
        /// </summary>
        void Initialize(ObjectPool currentPool);

        /// <summary>
        /// Желаемое максимальное количество объектов в пуле
        /// </summary>
        int MaxCountInPool { get; set; }
        /// <summary>
        /// Количество объектов, создаваемое при пустом пуле
        /// </summary>
        int CountToCreatedInPool { get; set; }
        /// <summary>
        /// Количество объектов, удаляемое за один апдейт из пула
        /// </summary>
        int CountToDeletedInPool { get; set; }
        /// <summary>
        /// Желаемое максимальное количество объектов в пуле
        /// </summary>
        float PoolUpdateTimeInterval { get; set; }
        /// <summary>
        /// Вызывается при возвращении в пул
        /// </summary>
        event System.Action OnToPoolReturned;
        /// <summary>
        /// Использовать для возвращения в пул
        /// </summary>
        void ReturnToPool(float delay);
        /// <summary>
        /// Использовать для возвращения в пул
        /// </summary>
        void ReturnToPool();
    }
}
