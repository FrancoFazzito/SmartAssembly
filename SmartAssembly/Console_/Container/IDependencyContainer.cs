using System;

namespace Console_.Container
{
    public interface IDependencyContainer
    {
        void Register<T>(Func<T> createInstance, string typeName = null);

        T Resolve<T>(string typeName = null);
    }
}