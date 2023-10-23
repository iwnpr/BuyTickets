using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using BuyTickets.Storages;

namespace BuyTickets.Facades
{
    public class BuyTicketsFacade : IBuyTicketsFacade
    {
        public BuyTicketsFacade(ITicketStorage ticketStorage, IPurchaseStorage purchaseStorage, IBuyerStorage buyerStorage)
        {
            _ticketStorage = ticketStorage;
            _purchaseStorage = purchaseStorage;
            _buyerStorage = buyerStorage;
        }

        private readonly ITicketStorage _ticketStorage;
        private readonly IPurchaseStorage _purchaseStorage;
        private readonly IBuyerStorage _buyerStorage;

        public Guid AddTicket(Cities from, Cities to, DateTime dateAndTime)
        {
            return _ticketStorage.AddTicket(from, to, dateAndTime);
        }

        public void DeleteTicket(Guid ticketId)
        {
            _ticketStorage.DeleteTicket(ticketId);
        }

        public void SellTicket(Guid ticketId)
        {
            _ticketStorage.SellTicket(ticketId);
        }

        public void ReturnTicket(Guid ticketId)
        {
            _ticketStorage.ReturnTicket(ticketId);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketStorage.GetAllTickets();
        }

        public List<Ticket> GetSoldTickets()
        {
            return _ticketStorage.GetSoldTickets();
        }

        public List<Ticket> GetUnsoldTickets()
        {
            return _ticketStorage.GetUnsoldTickets();
        }
    }
}
