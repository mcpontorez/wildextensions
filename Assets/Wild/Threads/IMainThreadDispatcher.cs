using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild.Threads
{
    public interface IMainThreadDispatcher
    {
        void Invoke(Action action);
        void Invoke<T>(Action<T> action, T arg);
    }
}
