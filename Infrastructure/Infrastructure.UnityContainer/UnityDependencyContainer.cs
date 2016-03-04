using Infrastructure.Common.IoC;
using Microsoft.Practices.Unity;

namespace Infrastructure.UnityContainer
{
    public class UnityDependencyContainer : IDependencyContainer
    {
        public IDependencyRegistry Registry { get; set; }
        public IDependencyResolver Resolver { get; set; }
        public object Container { get; private set; }

        public UnityDependencyContainer()
        {
            Container = new Microsoft.Practices.Unity.UnityContainer();
            Registry = new UnityRegistry(Container as IUnityContainer);
            Resolver = new UnityResolver(Container as IUnityContainer);
        }
    }
}
