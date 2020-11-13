﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLS.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public int PublishingYear { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
