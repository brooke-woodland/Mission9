using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem (Book book, int qty)
        {
            // add book that has matching id to the cart as a line item
            CartLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();
            // if book has already been added, update quantity, if not, add
            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty
                });

            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
                    
        }
        public virtual void ClearCart()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            //caluculate total cost of all items
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }

    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
