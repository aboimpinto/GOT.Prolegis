using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;

namespace GOT.Prolegis.WIN8.Libs
{
    public class ImagoContainer
    {
        private static ImagoContainer _currentContainer;
        private ContainerConfiguration _containerConfiguration;
        private CompositionHost _container;

        public static ImagoContainer CurrentContainer 
        {
            get
            {
                if (_currentContainer == null) _currentContainer = new ImagoContainer();
                return _currentContainer;
            }
        }

        public ImagoContainer()
        {
            _containerConfiguration = new ContainerConfiguration().WithAssembly(typeof(App).GetTypeInfo().Assembly);
            _container = _containerConfiguration.CreateContainer();
        }

        public void SatisfyImports(object objectWithLooseImports)
        {
            _container.SatisfyImports(objectWithLooseImports);
        }

        public T GetExport<T>()
        {
            return _container.GetExport<T>();
        }

        public IEnumerable<T> GetExports<T>()
        {
            return _container.GetExports<T>();
        }
    }
}
