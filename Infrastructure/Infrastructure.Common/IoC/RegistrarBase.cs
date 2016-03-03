using System;

namespace Infrastructure.Common.IoC
{
    public abstract class RegistrarBase : IDependencyRegistrar
    {
        protected DependencyRegistrarOptions _options { get; set; }

        protected RegistrarBase()
        {
            _options = new DependencyRegistrarOptions();
        }

        public bool IsRegistered<T>(string name = null)
        {
            return IsRegistered(typeof(T), name);
        }

        public abstract bool IsRegistered(Type typeToCheck, string name = null);

        public IDependencyRegistrar Name(string name)
        {
            _options.Name = name;
            return this;
        }

        public IDependencyRegistrar Singleton(object instance = null)
        {
            _options.Singleton = true;
            _options.SingletonInstance = instance;
            return this;
        }

        public IDependencyRegistrar From(Type from)
        {
            _options.From = from;
            return this;
        }

        public IDependencyRegistrar To(Type to)
        {
            _options.To = to;
            return this;
        }

        public IDependencyRegistrar ConstuctorParameters(params object[] constuctorParameters)
        {
            _options.ConstuctorParameters = constuctorParameters;
            return this;
        }

        public abstract IDependencyRegistrar Register(string name = null);

        public IDependencyRegistrar Register<TFrom, TTo>(string name = null)
        {
            return Register(typeof(TFrom), typeof(TTo), name);
        }

        public abstract IDependencyRegistrar Register(Type from, Type to, string name = null);


        protected void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _options.Name = name;
        }

        protected void ResetRegisterOptions()
        {
            _options = new DependencyRegistrarOptions();
        }
    }
}
