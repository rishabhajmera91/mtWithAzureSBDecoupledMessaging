using System;
using System.Collections.Generic;

namespace Infrastructure.Common.IoC
{
    public interface IDependencyResolver
    {
        TFrom Resolve<TFrom>(string name = null, IDictionary<string, object> parameterOverrides = null, IDictionary<string, object> propertyOverrides = null);
        object Resolve(Type t, string name = null, IDictionary<string, object> parameterOverrides = null, IDictionary<string, object> propertyOverrides = null);
        IEnumerable<T> ResolveAll<T>();
        IEnumerable<object> ResolveAll(Type t);
    }
}
