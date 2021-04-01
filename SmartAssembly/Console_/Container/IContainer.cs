using System;

namespace Console_.Container
{
    public interface IContainer
    {
        void Register<T>(Func<T> createInstance, string instanceName = null);

        T Resolve<T>(string instanceName = null);
    }
}