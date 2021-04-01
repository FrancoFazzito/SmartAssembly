using System;
using System.Collections.Generic;

namespace Console_.Container
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Tuple<Type, string>, Func<object>> mappings;

        public DependencyContainer()
        {
            mappings = new Dictionary<Tuple<Type, string>, Func<object>>();
        }

        //register
        public void Register<T>(Func<T> createInstance, string typeName = null)
        {
            Register(typeof(T), createInstance as Func<object>, typeName);
        }

        private void Register(Type type, Func<object> createInstanceDelegate, string typeName = null)
        {
            mappings.Add(CreateMapping(type, typeName), createInstanceDelegate);
        }

        //resolve
        public T Resolve<T>(string typeName = null)
        {
            return (T)Resolve(typeof(T), typeName);
        }

        private object Resolve(Type type, string typeName = null)
        {
            return mappings[CreateMapping(type, typeName)]();
        }

        private Tuple<Type, string> CreateMapping(Type type, string instanceName)
        {
            return new Tuple<Type, string>(type, instanceName);
        }
    }
}