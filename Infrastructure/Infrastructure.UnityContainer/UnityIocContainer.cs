using Infrastructure.Common.IoC;
using Microsoft.Practices.Unity;

namespace Infrastructure.UnityContainer
{
    public class UnityIocContainer : IContainer
    {
        public IDependencyRegistrar Registrar { get; set; }
        public IDependencyResolver Resolver { get; set; }
        public object Container { get; private set; }

        public UnityIocContainer()
        {
            Container = new Microsoft.Practices.Unity.UnityContainer();
            Registrar = new UnityRegistrar(Container as IUnityContainer);
            Resolver = new UnityResolver(Container as IUnityContainer);
        }
    }
}
