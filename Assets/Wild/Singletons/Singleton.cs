namespace Wild.Singletons
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        protected Singleton() { }

        private static T _instance;
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                    _instance.Initialize();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Использовать для инициализации объекта синглотона
        /// </summary>        protected virtual void Initialize() { }

        /// <summary>
        /// Использовать для создания объекта синглотона до первого обращения к Instance
        /// </summary>
        public static T Register()
        {
            return Instance;
        }
    }
}
