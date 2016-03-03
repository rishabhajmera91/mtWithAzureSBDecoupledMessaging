using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Common.IoC;
using Microsoft.Practices.Unity;

namespace Infrastructure.UnityContainer
{
    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object Resolve(Type t, string name = null, IDictionary<string, object> parameterOverrides = null, IDictionary<string, object> propertyOverrides = null)
        {
            var overrides = CreateOverrides(parameterOverrides, propertyOverrides);
            if (overrides != null)
                return _container.Resolve(t, name, overrides);
            return _container.Resolve(t, name);
        }

        public T Resolve<T>(string name = null, IDictionary<string, object> parameterOverrides = null, IDictionary<string, object> propertyOverrides = null)
        {
            var overrides = CreateOverrides(parameterOverrides, propertyOverrides);
            if (overrides != null)
                return (T)_container.Resolve(typeof(T), name, overrides);
            return (T)_container.Resolve(typeof(T));
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        public IEnumerable<object> ResolveAll(Type t)
        {
            return _container.ResolveAll(t);
        }

        #region private methods

        private static ResolverOverride[] CreateOverrides(IDictionary<string, object> parameterOverrides, IDictionary<string, object> propertyOverrides)
        {
            var constructorOverrides = CreateConstructorOverrides(parameterOverrides);
            var propOverrides = CreatePropertyOverrides(propertyOverrides);
            if (constructorOverrides == null) return propOverrides;
            if (propertyOverrides == null) return constructorOverrides;

            var overrides = constructorOverrides.Concat(propOverrides).ToArray();
            return overrides;
        }

        private static ResolverOverride[] CreateConstructorOverrides(IDictionary<string, object> parameterOverrides)
        {
            if (parameterOverrides == null || parameterOverrides.Count == 0) return null;
            var overrides = parameterOverrides.Select(a => new ParameterOverride(a.Key, a.Value)).ToArray();
            return overrides;
        }

        private static ResolverOverride[] CreatePropertyOverrides(IDictionary<string, object> propertyOverrides)
        {
            if (propertyOverrides == null || propertyOverrides.Count == 0) return null;
            var overrides = propertyOverrides.Select(a => new PropertyOverride(a.Key, a.Value)).ToArray();
            return overrides;
        }

        #endregion



    }
}
