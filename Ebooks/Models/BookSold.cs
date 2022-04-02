using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebooks.Models
{
    public class BookSold
    {
        public int Book_id { get; set; }
        public int Book_qty_sold { get; set; }

        public string Book_image { get; set; }

        public string Book_name { get; set; }

        public double Book_price { get; set; }
    }
}