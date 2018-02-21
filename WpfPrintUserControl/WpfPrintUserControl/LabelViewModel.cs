namespace WpfPrintUserControl
{
    public class LabelViewModel 
    {
        private string _text1;

        public string Text1
        {
            get { return _text1 ?? ""; }
            set { _text1 = value; }
        }

        private string _text2;

        public string Text2
        {
            get { return _text2 ?? ""; }
            set { _text2 = value; }
        }

        private string _text3;

        public string Text3
        {
            get { return _text3 ?? ""; }
            set { _text3 = value; }
        }
    }
}
