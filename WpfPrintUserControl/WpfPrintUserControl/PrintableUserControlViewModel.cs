using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrintUserControl
{
    public class PrintableUserControlViewModel
    { 
        private LabelViewModel[] _labelViewModels = new LabelViewModel[]
        {
            new LabelViewModel(), new LabelViewModel(), new LabelViewModel(), new LabelViewModel(), new LabelViewModel(), new LabelViewModel(),
            new LabelViewModel(), new LabelViewModel(), new LabelViewModel(), new LabelViewModel(), new LabelViewModel(), new LabelViewModel()
        };
        
        public LabelViewModel[] LabelViewModels
        {
            get { return _labelViewModels; }
        }

        private int _numberOfLabelsToPrint;

        public int NumberOfLabelsToPrint
        {
            get { return _numberOfLabelsToPrint; }
        }

        private bool _fitToPage;

        public bool FitToPage
        {
            get { return _fitToPage; }
        }

        private bool _needToShowDialog;

        public bool NeedToShowDialog
        {
            get { return _needToShowDialog; }
        }

        public PrintableUserControlViewModel(int numberOfLabelsToPrint, bool fitToPage, bool needToShowDialog)
        {
            _numberOfLabelsToPrint = numberOfLabelsToPrint;
            _fitToPage = fitToPage;
            _needToShowDialog = needToShowDialog;
        }
    }
}
