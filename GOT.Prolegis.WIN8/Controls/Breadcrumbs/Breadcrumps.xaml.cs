using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace GOT.Prolegis.WIN8.Controls.Breadcrumbs
{
    public sealed partial class Breadcrumps : UserControl
    {
        #region Dependency Properties 
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(string), typeof(Breadcrumps), new PropertyMetadata(" ", new PropertyChangedCallback(BreadcrumpsChanged)));
        #endregion

        #region Public Properties 
        public string ItemsSource
        {
            get { return (string)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        #endregion

        #region Constructor 
        public Breadcrumps() 
        {
            this.InitializeComponent();
        }
        #endregion

        #region Public Static Methods 
        private static void BreadcrumpsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
        { 

        }
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
