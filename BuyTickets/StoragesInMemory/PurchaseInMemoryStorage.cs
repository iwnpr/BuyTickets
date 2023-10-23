using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using BuyTickets.Storages;

namespace BuyTickets.StoragesInMemory
{
    public class PurchaseInMemoryStorage : IPurchaseStorage
    {
        public PurchaseInMemoryStorage()
        {
            _purchases = new List<Purchase>();
        }

        private readonly List<Purchase> _purchases;

        public Guid AddPurchase(Guid buyerId, Guid ticketId)
        {
            var purchase = new Purchase(ticketId, buyerId);
            _purchases.Add(purchase);

            return purchase.Id;

        }

        public void RemovePurchase(Guid purchaseId)
        {
            var isPurchase = _purchases.Any(p => p.Id == purchaseId);

            if (isPurchase)
            {
                var purchase = _purchases.Single(p => p.Id == purchaseId);
                _purchases.Remove(purchase);
            }
        }

        public List<Purchase> GetAllPurchases()
        {
            return _purchases;
        }
        
    }
}
