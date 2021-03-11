using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amazon.Pages
{
    public class PurchaseModel : PageModel
    {
        private IAmazonRepository repository;

        //constructor
        public PurchaseModel (IAmazonRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //methods
        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.BookID == bookID);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //function to remove an item from cart
        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookID == bookID).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
