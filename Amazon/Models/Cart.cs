using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Book book, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookID == book.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
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

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(e => (decimal)e.Book.Price * (decimal)(e.Quantity));
        

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get;set; }
            public int Quantity { get; set; }
        }

    }
}
