using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;

namespace BuyTickets.Facades
{
    public interface IBuyTicketsFacade
    {
        Guid AddTicket(Cities from, Cities to, DateTime dateAndTime);

        void DeleteTicket(Guid ticketId);

        void SellTicket(Guid ticketId);

        void ReturnTicket(Guid ticketId);

        List<Ticket> GetAllTickets();

        List<Ticket> GetSoldTickets();

        List<Ticket> GetUnsoldTickets();


    }
}
