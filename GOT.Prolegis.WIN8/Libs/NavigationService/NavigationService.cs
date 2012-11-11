using GOT.Prolegis.WIN8.Libs.MVVM;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GOT.Prolegis.WIN8.Libs.NavigationService
{
    [Export(typeof(INavigationService))]
    [Shared]
    public class NavigationService : INavigationService
    {
        #region Private Fields 
        private Frame _frame;
        #endregion

        #region Public Properties
        [ImportMany]
        public IEnumerable<Lazy<Page, WindowMetadata>> LazyWindowList { get; set; }
        #endregion

        #region Constructor
        public NavigationService()
        {
            ImagoContainer.CurrentContainer.SatisfyImports(this);
        }
        #endregion

        #region INavigationService Implementation
        public Frame Frame 
        {
            get { return _frame; }
            set 
            {
                _frame = value;
                Frame.Navigated += OnFrameNavigated;
            }
        }

        public void Navigate(string pageName)
        {
            var oWindow = this.LazyWindowList.Single(x => x.Metadata.Name == pageName).Value;
            if (oWindow.DataContext is ProlegisViewModelBase) ((ProlegisViewModelBase)oWindow.DataContext).InitializeViewModel();

            if (this.Frame == null) throw new Exception("Navigation Service as lost the Frame!");
            this.Frame.Navigate(oWindow.GetType());
        }
        #endregion

        #region Private Methods 
        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {

        }
        #endregion
    }
}
