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
    /// Interaction logic for PngView.xaml
    /// </summary>
    public partial class PngView : Window
    {
        private string _path;
        private static string _digits = "0123456789ABCDEF";
        private static char[] _hexchars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public PngView(string path)
        {
            InitializeComponent();
            _path = path;
            FillTable();
        }

        public void FillTable()
        {
            ReadPng();
        }

        public void ReadPng()
        {
            byte[] cont = File.ReadAllBytes(_path);            
            int index = 1;

            // read chunks
            for (int i = 8; i < cont.Length;)
            {
                string lengthHexaDecimal = "";// length in hexadecimal n.s.
                bool isNotFirst = false;

                // first 4 bytes is the length
                for (int j = i; j < i + 4; j++)
                {
                    if (cont[j] == 0 && isNotFirst == false)
                    {
                        continue;
                    }
                    var temp = ConvertDecimalToHexadecimal(cont[j]);
                    if (temp == "0")
                    {
                        lengthHexaDecimal += "00";
                        continue;
                    }
                    lengthHexaDecimal += temp;
                    isNotFirst = true;
                }
                var length = ConvertHexadecimalToDecimal(lengthHexaDecimal);// 16 -> 10 n.s.

                // next 4 bytes is the name of the chunk
                string name = "";
                for (int j = i + 4; j < i + 8; j++)
                {
                    name += (char)cont[j];
                }

                var query = new PngModel(index++, name, length);
                InfosDG.Items.Add(query);

                i += length + 12;// 12 bytes = length + name + CRC (4+4+4)
            }
        }

        private int ConvertHexadecimalToDecimal(string hex)
        {
            hex = hex.ToUpper();
            int value = 0;

            for (int i = 0; i < hex.Length; i++)
            {
                char current = hex[i];
                int index = _digits.IndexOf(current);
                value = 16 * value + index;
            }

            return value;
        }

        private string ConvertDecimalToHexadecimal(int number)
        {
            if (number == 0)
            {
                return "0";
            }

            int rem;
            string hex = "";
            
            while (number > 0)
            {
                rem = number % 16;
                hex = _hexchars[rem] + hex;
                number /= 16;
            }
           
            return hex;
        }

        void WriteSignature(byte[] cont)
        {
            for (int i = 0; i < 8; i++)
            { // read signature (first 8 byte)
                Console.Write((cont[i] & 0xFF) + " ");
            }
        }
    }
}
