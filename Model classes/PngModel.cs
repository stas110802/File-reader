using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PngReader.Model_classes
{
    public class PngModel
    {
        public PngModel(int id, string nameChank, int length)
        {
            ID = id;
            NameChank = nameChank;
            Length = length;
        }
        public int ID { get; set; }
        public string NameChank { get; set; }
        public int Length { get; set; }
    }
}
