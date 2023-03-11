using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStore.Models
{
    public class EFCartRepository : ICartRepository
    {
        private BookstoreContext context;
        public EFCartRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Cart> Carts => context.Cart.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCart(Cart cart)
        {
            context.AttachRange(cart.Lines.Select(x => x.Book));

            if (cart.CartId == 0 )
            {
                context.Cart.Add(cart);
            }

            context.SaveChanges();
        }
    }
}
