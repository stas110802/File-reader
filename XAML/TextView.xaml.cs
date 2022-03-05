using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using PngReader.Model_classes;

namespace PngReader.XAML
{
    /// <summary>
    /// Interaction logic for TextView.xaml
    /// </summary>
    public partial class TextView : Window
    {
        private readonly string _path;

        public TextView(string path)
        {
            InitializeComponent();
            _path = path;
            FillTable();
        }

        public void FillTable()
        {
            using var file = new StreamReader(_path);
            var line = file.ReadLine();
            var index = 1;

            while (line != null)
            {
                var count = GetCountOfWord(line);
                InfosDG.Items.Add(
                     new TextModel(index++, line, count));
                line = file.ReadLine();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            FillTable();
        }

        private int GetCountOfWord(string line)
        {
            if (line == "")
            {
                return 0;
            }

            int count = 1;

            foreach (var item in line)
            {
                if (item == ' ')
                {
                    count++;
                }
            }

            return count;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            InfosDG.Items.Clear();
        }
    }
}
