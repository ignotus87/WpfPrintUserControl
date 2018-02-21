using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPrintUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new PrintableUserControlViewModel(int.Parse(((ComboBoxItem)NumberOfLabelsToPrint.SelectedValue).Content.ToString()), (bool)FitToPage.IsChecked, (bool)NeedToShowDialog.IsChecked);

            for (int labelIndex = 0; labelIndex < viewModel.NumberOfLabelsToPrint; ++labelIndex)
            {
                viewModel.LabelViewModels[labelIndex].Text1 = string.Format("test{0}.1", labelIndex + 1);
                viewModel.LabelViewModels[labelIndex].Text2 = string.Format("test{0}.2", labelIndex + 1);
                viewModel.LabelViewModels[labelIndex].Text3 = string.Format("test{0}.3", labelIndex + 1);
            }
            
            var view = new PrintableUserControl(viewModel);

            PrintDialog printDialog = new PrintDialog();

            bool printDialogResult = true;

            if (viewModel.NeedToShowDialog)
            {
                printDialogResult = printDialog.ShowDialog() ?? false;
            }
            else
            {
                printDialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue(); // can also select one of new PrintServer().GetPrintQueues();
                printDialog.PrintTicket.CopyCount = 1; // number of copies
                printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            }
            
            if (viewModel.FitToPage)
            { 
                //get selected printer capabilities
                System.Printing.PrintCapabilities capabilities = printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket);

                //get scale of the printer to that of WPF control
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / view.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
                        view.ActualHeight);

                //Scare the control for printing size
                view.LayoutTransform = new ScaleTransform(scale, scale);

                Size sizeOfPrinterPage = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                //Update the layout of the control to the size of the printer page
                view.Measure(sizeOfPrinterPage);
                view.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sizeOfPrinterPage));
            }

            //print the control to printer 
            printDialog.PrintVisual(view, "Print title");
        }
    }
}
