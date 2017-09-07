using System;

namespace Wild.Generics
{
    public class GenericNewTypeContainer<TBase> : IGenericNewTypeContainer<TBase>
    {
        public GenericNewTypeContainer() { }

        private Type _genericType;
        public Type GetGenericType()
        {
            return _genericType;
        }

        public void SetGenericType<T>() where T : TBase, new()
        {
            _genericType = typeof(T);
        }

        public void SetGenericType<T>(T someObject) where T : TBase, new()
        {
            SetGenericType<T>();
        }
    }
}
