using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;

namespace BuyTickets.Storages
{
    public interface IBuyerStorage
    {
        Guid AddBuyer(string name);

        void DeleteBuyer(Guid buyerId);

        List<Buyer> GetAllBuyers();
    }
}
