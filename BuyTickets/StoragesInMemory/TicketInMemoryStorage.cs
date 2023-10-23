using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using BuyTickets.Storages;

namespace BuyTickets.StoragesInMemory
{
    public class TicketInMemoryStorage : ITicketStorage
    {
        public TicketInMemoryStorage()
        {
            _tickets = new List<Ticket>();
        }
        
        private readonly List<Ticket> _tickets;

        public Guid AddTicket(Cities from, Cities to, DateTime dateAndTime)
        {
            var ticket = new Ticket(from, to, dateAndTime);
            _tickets.Add(ticket);

            return ticket.Id;
        }

        public void DeleteTicket(Guid ticketId)
        {
            var isTicket = _tickets.Any(t => t.Id == ticketId);

            if (isTicket)
            {
                var ticket = _tickets.Single(t => t.Id == ticketId);
                _tickets.Remove(ticket);
                
            }
        }

        public List<Ticket> GetAllTickets()
        {
            return _tickets;
        }

        public void SellTicket(Guid ticketId)
        {
            var isTicket = _tickets.Any(t => t.Id == ticketId);

            if (isTicket)
            {
                var ticket = _tickets.Single(t => t.Id == ticketId);
                ticket.Sell();
                
            }
        }

        public void ReturnTicket(Guid ticketId)
        {
            var isTicket = _tickets.Any(t => t.Id == ticketId);

            if (isTicket)
            {
                var ticket = _tickets.Single(t => t.Id == ticketId);
                ticket.Return();

            }
            
        }

        public List<Ticket> GetSoldTickets()
        {
            var tickets = _tickets.Where(t => t.IsSelling == true);
            return _tickets;
        }

        public List<Ticket> GetUnsoldTickets()
        {
            var tickets = _tickets.Where(t => t.IsSelling == false);

            return _tickets;
        }
    }
}
