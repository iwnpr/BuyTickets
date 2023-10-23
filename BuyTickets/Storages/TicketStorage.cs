using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;

namespace BuyTickets.Storages
{
    class TicketStorage : ITicketStorage
    {
        public TicketStorage()
        {
            _buyTicketsContext = new BuyTicketsContext();
        }

        private readonly BuyTicketsContext _buyTicketsContext;

        public Guid AddTicket(Cities from, Cities to, DateTime dateAndTime)
        {
            var ticket = new Ticket(from, to, dateAndTime);
            _buyTicketsContext.Add(ticket);
            _buyTicketsContext.SaveChanges();

            return ticket.Id;
        }

        public void DeleteTicket(Guid ticketId)
        {
            var ticket = _buyTicketsContext.Tickets.Single(t => t.Id == ticketId);
            _buyTicketsContext.Tickets.Remove(ticket);

            _buyTicketsContext.SaveChanges();

        }

        public void SellTicket(Guid ticketId)
        {
            var ticket = _buyTicketsContext.Tickets.Single(t => t.Id == ticketId);
            ticket.Sell();

            _buyTicketsContext.Tickets.Update(ticket);
            _buyTicketsContext.SaveChanges();

        }

        public void ReturnTicket(Guid ticketId)
        {
            var ticket = _buyTicketsContext.Tickets.Single(t => t.Id == ticketId);
            ticket.Return();

            _buyTicketsContext.Tickets.Update(ticket);
            _buyTicketsContext.SaveChanges();
        }

        public List<Ticket> GetAllTickets()
        {
            return _buyTicketsContext.Tickets.ToList();
        }

        public List<Ticket> GetSoldTickets()
        {
            var tickets = _buyTicketsContext.Tickets.Where(t => t.IsSelling == true);

            return tickets.ToList();
        }

        public List<Ticket> GetUnsoldTickets()
        {
            var tickets = _buyTicketsContext.Tickets.Where(t => t.IsSelling == false);

            return tickets.ToList();
        }
    }
}
