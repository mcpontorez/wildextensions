using System;

namespace Wild.Generics
{
    public class GenericTypeContainer<TBase> : IGenericTypeContainer<TBase>
    {
        public GenericTypeContainer() { }

        private Type _genericType;
        public Type GetGenericType()
        {
            return _genericType;
        }

        public void SetGenericType<T>() where T : TBase
        {
            _genericType = typeof(T);
        }

        public void SetGenericType<T>(T someObject) where T : TBase
        {
            SetGenericType<T>();
        }
    }
}
