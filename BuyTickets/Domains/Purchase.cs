using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTickets.Domains
{
    public class Purchase
    {
        public Purchase(Guid ticketId, Guid buyerId)
        {
            Id = Guid.NewGuid();
            TicketId = ticketId;
            BuyerId = buyerId;
        }

        public Guid Id { get; }

        public Guid TicketId { get; }

        public Guid BuyerId { get; }

    }
}
