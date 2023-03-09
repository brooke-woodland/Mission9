using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9.Infrastructure;
using Mission9.Models;

namespace Mission9.Pages
{
    public class ShopModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public ShopModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            // create a new cart if one does not exist, if it does, go to the cart
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            //pass the book object to the shop page in a Json format so it can be a string and have all the info needed
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
