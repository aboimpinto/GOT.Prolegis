using System.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GOT.Prolegis.WIN8.Views
{
    [Export(typeof(Page))]
    [ExportMetadata("Name", "EditEntity")]
    public sealed partial class EditEntity : Page
    {
        public EditEntity()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
