using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using BuyTickets.Storages;
using BuyTickets.StoragesInMemory;
using BuyTickets.Facades;

namespace BuyTicketsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticketStorage = new TicketInMemoryStorage();
            var buyerStorage = new BuyerInMemoryStorage();
            var purchaseStorage = new PurchaseInMemoryStorage();

            var ticketFacade = new BuyTicketsFacade(ticketStorage, purchaseStorage, buyerStorage);
            var buyerFacade = new BuyerFacade(buyerStorage);

            var ticketId = ticketFacade.AddTicket(Cities.Moscow, Cities.Warsaw, DateTime.Now);
            var buyerId = buyerFacade.AddBuyer("Ivanov Ivan Ivanovich");

            ticketFacade.SellTicket(ticketId);




        }
    }
}
