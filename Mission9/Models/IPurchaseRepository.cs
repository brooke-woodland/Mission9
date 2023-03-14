using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchase { get; }

        public void SavePurchase(Purchase purchase);
    }
}
