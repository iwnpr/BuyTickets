using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using BuyTickets.Storages;

namespace BuyTickets.Facades
{
    public class BuyerFacade : IBuyerFacade
    {
        public BuyerFacade(IBuyerStorage buyerStorage)
        {
            _buyerStorage = buyerStorage;
        }

        private readonly IBuyerStorage _buyerStorage;

        public Guid AddBuyer(string name)
        {
            return _buyerStorage.AddBuyer(name);
        }

        public void DeleteBuyer(Guid buyerId)
        {
            _buyerStorage.DeleteBuyer(buyerId);
        }

        public List<Buyer> GetAllBuyers()
        {
            return _buyerStorage.GetAllBuyers();
        }
    }
}