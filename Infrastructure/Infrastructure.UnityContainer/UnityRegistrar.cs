using System;
using Infrastructure.Common.IoC;
using Microsoft.Practices.Unity;

namespace Infrastructure.UnityContainer
{
    public class UnityRegistrar : RegistrarBase
    {
        private readonly IUnityContainer _container;

        public UnityRegistrar(IUnityContainer container)
        {
            _container = container;
        }

        public override bool IsRegistered(Type typeToCheck, string name = null)
        {
            return _container.IsRegistered(typeToCheck, name);
        }

        public override IDependencyRegistrar Register(Type from, Type to, string name = null)
        {
            _options.From = from;
            _options.To = to;
            return Register(name);
        }

        public override IDependencyRegistrar Register(string name = null)
        {
            SetName(name);
            RegisterFromOptions();
            ResetRegisterOptions();
            return this;
        }

        #region private methods

        private void RegisterFromOptions()
        {
            if (IsNonSingleton())
                RegisterNonSingleton();
            else if (HasSingletonInstance())
                RegisterSingletonInstance();
            else
                RegisterSingleton();
        }

        private bool IsNonSingleton()
        {
            return !_options.Singleton;
        }

        private void RegisterNonSingleton()
        {
            RegisterWithLifeTimeManager(new TransientLifetimeManager());
        }

        private bool HasSingletonInstance()
        {
            return _options.SingletonInstance != null;
        }

        private void RegisterSingletonInstance()
        {
            _container.RegisterInstance(_options.From, _options.Name, _options.SingletonInstance);
        }

        private void RegisterSingleton()
        {
            RegisterWithLifeTimeManager(new ContainerControlledLifetimeManager());
        }

        private void RegisterWithLifeTimeManager(LifetimeManager lifetimeManager)
        {
            if (HasConstructorInjection())
            {
                var constructorInjection = GetConstructorInjection();
                _container.RegisterType(_options.From, _options.To, _options.Name, lifetimeManager, constructorInjection);
                return;
            }

            _container.RegisterType(_options.From, _options.To, _options.Name, lifetimeManager);
        }

        private InjectionConstructor GetConstructorInjection()
        {
            return new InjectionConstructor(_options.ConstuctorParameters);
        }

        private bool HasConstructorInjection()
        {
            return _options.ConstuctorParameters != null && _options.ConstuctorParameters.Length > 0;
        }


        #endregion
    }
}
