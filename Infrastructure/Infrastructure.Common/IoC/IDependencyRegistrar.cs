using System;

namespace Infrastructure.Common.IoC
{
    public interface IDependencyRegistrar
    {
        bool IsRegistered<T>(string name = null);
        bool IsRegistered(Type typeToCheck, string name = null);
        IDependencyRegistrar Name(string name);
        IDependencyRegistrar Singleton(object instance = null);
        IDependencyRegistrar From(Type from);
        IDependencyRegistrar To(Type to);
        IDependencyRegistrar ConstuctorParameters(params object[] constuctorParameters);
        IDependencyRegistrar Register(string name = null);
        IDependencyRegistrar Register<TFrom, TTo>(string name = null);
        IDependencyRegistrar Register(Type from, Type to, string name = null);
    }
}
