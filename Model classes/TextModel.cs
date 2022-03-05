using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PngReader.Model_classes
{
    public class TextModel
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public int CountWord { get; set; }

        public TextModel(int id, string data, int countWord)
        {
            ID = id;
            Data = data;
            CountWord = countWord;
        }
    }
}
