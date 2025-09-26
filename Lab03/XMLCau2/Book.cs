using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCau2
{
    internal class Book
    {
        public string ISBN {  get; set; }
        public string Title {  get; set; }
        public string Author {  get; set; }
        public decimal Price {  get; set; }
        public int YearPublished {  get; set; }
    }
}
