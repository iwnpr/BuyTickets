using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;

namespace BuyTickets.Storages
{
    class BuyerStorage : IBuyerStorage
    {
        public BuyerStorage()
        {
            _buyTicketsContext = new BuyTicketsContext();
        }

        private readonly BuyTicketsContext _buyTicketsContext;

        public Guid AddBuyer(string name)
        {
            var buyer = new Buyer(name);
            _buyTicketsContext.Add(buyer);
            _buyTicketsContext.SaveChanges();

            return buyer.Id;
        }

        public void DeleteBuyer(Guid buyerId)
        {
            var buyer = _buyTicketsContext.Buyers.Single(b => b.Id == buyerId);
            _buyTicketsContext.Buyers.Remove(buyer);

            _buyTicketsContext.SaveChanges();
        }

        public List<Buyer> GetAllBuyers()
        {
            return _buyTicketsContext.Buyers.ToList();
        }
    }
}
