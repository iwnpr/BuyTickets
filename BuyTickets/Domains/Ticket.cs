using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTickets.Domains
{
    public class Ticket : Flight
    {
        public Ticket(Cities from, Cities to, DateTime dateAndTime) : base(from, to, dateAndTime)
        {
            Id = Guid.NewGuid();
            IsSelling = false;
        }

        public Guid Id { get;}
        
        public bool IsSelling { get; private set; }

        public void Sell()
        {
            IsSelling = true;
        }

        public void Return()
        {
            IsSelling = false;
        }
        
    }
}
