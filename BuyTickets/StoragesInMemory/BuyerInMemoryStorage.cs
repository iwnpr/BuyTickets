using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using BuyTickets.Storages;

namespace BuyTickets.StoragesInMemory
{
    public class BuyerInMemoryStorage : IBuyerStorage
    {
        public BuyerInMemoryStorage()
        {
            _buyers = new List<Buyer>();
        }

        private readonly List<Buyer> _buyers; 

        public Guid AddBuyer(string name)
        {
            var buyer = new Buyer(name);
            _buyers.Add(buyer);

            return buyer.Id;
        }

        public void DeleteBuyer(Guid buyerId)
        {
            var isBuyer = _buyers.Any(b => b.Id == buyerId);

            if (isBuyer)
            {
                var buyer = _buyers.Single(b => b.Id == buyerId);
                _buyers.Remove(buyer);
                
            }
            
        }

        public List<Buyer> GetAllBuyers()
        {
            return _buyers;
        }
    }
}
