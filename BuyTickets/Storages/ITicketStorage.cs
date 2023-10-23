using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;

namespace BuyTickets.Storages
{
    public interface ITicketStorage
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
