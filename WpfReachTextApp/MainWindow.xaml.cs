using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfReachTextApp
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

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "RTF files(*.rtf)|*.rtf|All files (*.*)|*.*";

            if(openFile.ShowDialog() == true)
            {
                TextRange textDocument 
                    = new TextRange(
                    docBox.Document.ContentStart, 
                    docBox.Document.ContentEnd);
                using(FileStream stream = new(openFile.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(openFile.FileName).ToLower() == ".rtf")
                        textDocument.Load(stream, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(openFile.FileName).ToLower() == ".txt")
                        textDocument.Load(stream, DataFormats.Text);
                    else
                        textDocument.Load(stream, DataFormats.Xaml);
                }
            }
        }
    }
}