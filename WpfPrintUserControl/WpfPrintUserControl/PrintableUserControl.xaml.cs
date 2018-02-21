using System.Windows.Controls;

namespace WpfPrintUserControl
{
    /// <summary>
    /// Interaction logic for PrintableUserControl.xaml
    /// </summary>
    public partial class PrintableUserControl : UserControl
    {
        public PrintableUserControl(PrintableUserControlViewModel printableUserControlViewModel)
        {
            DataContext = printableUserControlViewModel;

            InitializeComponent();
        }
    }
}
