using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;

namespace BuyTickets.Storages
{
    class PurchaseStorage : IPurchaseStorage
    {
        public PurchaseStorage()
        {
            _buyTicketsContext = new BuyTicketsContext();
        }

        private readonly BuyTicketsContext _buyTicketsContext;

        public Guid AddPurchase(Guid buyerId, Guid ticketId)
        {
            var purchase = new Purchase(ticketId, buyerId);
            _buyTicketsContext.Add(purchase);
            _buyTicketsContext.SaveChanges();

            return purchase.Id;
            
        }

        public void RemovePurchase(Guid purchaseId)
        {
            var purchase = _buyTicketsContext.Purchases.Single(p => p.Id == purchaseId);
            _buyTicketsContext.Purchases.Remove(purchase);

            _buyTicketsContext.SaveChanges();
        }

        public List<Purchase> GetAllPurchases()
        {
            return _buyTicketsContext.Purchases.ToList();
        }
    }
}
