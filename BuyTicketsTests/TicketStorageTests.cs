using System;
using BuyTickets.Domains;
using BuyTickets.Storages;
using BuyTickets.StoragesInMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyTicketsTests
{
    [TestClass]
    public class TicketStorageTests
    {   
        //arange
        //act
        //assert
        private TicketInMemoryStorage _ticketInMemoryStorage;

        [TestInitialize]
        public void TicketStorageTestsInitiliaze()
        {
            _ticketInMemoryStorage = new TicketInMemoryStorage();
        }

        [TestMethod]
        [DataRow("Ivan", Cities.Paris, Cities.Prague)]

        public void TryAddTicket(Cities from, Cities to)
        {

        }
    }
}
