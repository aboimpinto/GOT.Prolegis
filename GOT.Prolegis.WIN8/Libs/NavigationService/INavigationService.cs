using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GOT.Prolegis.WIN8.Libs.NavigationService
{
    public interface INavigationService
    {
        Frame Frame { get; set; }

        void Navigate(string pageName);
    }
}
