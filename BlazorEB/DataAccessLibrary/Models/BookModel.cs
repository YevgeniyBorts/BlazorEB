using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class BookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
        public string Format { get; set; }
        public int Year { get; set; }
        public bool Read { get; set; }
    }
}