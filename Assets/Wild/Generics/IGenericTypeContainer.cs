using System;

namespace Wild.Generics
{
    public interface IGenericTypeContainer<TBase>
    {
        Type GetGenericType();
        void SetGenericType<T>() where T : TBase;
        void SetGenericType<T>(T someObject) where T : TBase;
    }
}
