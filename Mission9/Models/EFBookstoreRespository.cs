﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    //db first method
    public class EFBookstoreRespository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRespository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
