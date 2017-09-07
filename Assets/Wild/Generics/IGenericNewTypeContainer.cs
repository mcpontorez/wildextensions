using System;

namespace Wild.Generics
{
    public interface IGenericNewTypeContainer<TBase>
    {
        Type GetGenericType();
        void SetGenericType<T>() where T : TBase, new();
        void SetGenericType<T>(T someObject) where T : TBase, new();
    }
}
