﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface ICartRepository
    {
        IQueryable<Cart> Carts { get; }

        void SaveCart(Cart cart);
    }
}