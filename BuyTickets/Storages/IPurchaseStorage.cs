using System;
using System.Collections.Generic;
using BuyTickets.Domains;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTickets.Storages
{
    public interface IPurchaseStorage
    {
        Guid AddPurchase(Guid buyerId, Guid ticketId);

        void RemovePurchase(Guid purchaseId);

        List<Purchase> GetAllPurchases();
    }
}
