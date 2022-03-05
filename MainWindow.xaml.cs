using System;
using System.Collections.Generic;
using System.Linq;
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
using PngReader.XAML;

namespace PngReader
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

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            var path = PathTB.Text;

            if (path == "")
            {
                return;
            }
            else if (path.EndsWith(".txt"))
            {
                new TextView(path).Show();
            }
            else if (path.EndsWith(".png"))
            {
                new PngView().Show();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PathTB.Clear();
        }
    }
}
