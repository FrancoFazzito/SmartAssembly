using System;
using System.Collections.Generic;

namespace Console_.Container
{
    public class DependencyContainer : IContainer
    {
        private readonly Dictionary<Tuple<Type, string>, Func<object>> mappings;

        public DependencyContainer()
        {
            mappings = new Dictionary<Tuple<Type, string>, Func<object>>();
        }

        //register
        public void Register<T>(Func<T> createInstance, string instanceName = null)
        {
            Register(typeof(T), createInstance as Func<object>, instanceName);
        }

        private void Register(Type type, Func<object> createInstanceDelegate, string instanceName = null)
        {
            mappings.Add(CreateMapping(type, instanceName), createInstanceDelegate);
        }

        //resolve
        public T Resolve<T>(string instanceName = null)
        {
            return (T)Resolve(typeof(T), instanceName);
        }

        private object Resolve(Type type, string instanceName = null)
        {
            return mappings[CreateMapping(type, instanceName)]();
        }

        private Tuple<Type, string> CreateMapping(Type type, string instanceName)
        {
            return new Tuple<Type, string>(type, instanceName);
        }
    }
}