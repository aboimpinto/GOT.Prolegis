using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Libs.MVVM
{
    public class Locator
    {
        #region Public Properties 
        [ImportMany]
        public IList<Lazy<ProlegisViewModelBase, ViewModelMetadata>> ViewModelsLazy { get; set; }

        public object this[string viewModel]
        {
            get
            {
                return ViewModelsLazy.Single(x => x.Metadata.Name.Equals(viewModel)).Value;
            }
        }
        #endregion

        #region Constructor 
        public Locator() 
        {
            var containerConfiguration = new ContainerConfiguration().WithAssembly(typeof(App).GetTypeInfo().Assembly);
            CompositionHost host = containerConfiguration.CreateContainer();
            host.SatisfyImports(this);
        }
        #endregion
    }
}
