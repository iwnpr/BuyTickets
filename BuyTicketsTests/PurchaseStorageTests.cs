using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BuyTickets.StoragesInMemory;
using BuyTickets.Domains;


namespace BuyTicketsTests
{
    [TestClass]
    public class PurchaseStorageTests
    {
        private PurchaseInMemoryStorage _purchaseInMemoryStorage;
        private TicketInMemoryStorage _ticketInMemoryStorage;
        private BuyerInMemoryStorage _buyerInMemoryStorage;

        [TestInitialize]
        public void PurchaseStorageInizialize()
        {
            _purchaseInMemoryStorage = new PurchaseInMemoryStorage();
            _ticketInMemoryStorage = new TicketInMemoryStorage();
            _buyerInMemoryStorage = new BuyerInMemoryStorage();
            DateTime dateTime = new DateTime();
        }

        [TestMethod]
        [DataRow("Ivan", Cities.Paris, Cities.Prague)]

        public void AddPurchase(string name, Cities from, Cities to)
        {
            //arange
            DateTime dateTime = new DateTime(2001, 09, 11);
            var buyerId = _buyerInMemoryStorage.AddBuyer(name);
            var ticketId = _ticketInMemoryStorage.AddTicket(from, to, dateTime);

            //act
            _purchaseInMemoryStorage.AddPurchase(buyerId, ticketId);
            var actualTickets = _purchaseInMemoryStorage.GetAllPurchases();

            //assert
            var expectedResult = new List<Purchase>() { new Purchase(ticketId, buyerId) };
            Assert.AreEqual(expectedResult.Count, actualTickets.Count);
        }

        [TestMethod]
        [DataRow("Adam", Cities.Berlin, Cities.London)]
        [DataRow("Eva", Cities.Prague, Cities.Warsaw)]
        public void ShouldRemovePurchase(string name, Cities from, Cities to)
        {
            //arange
            DateTime dateTime = new DateTime(2001, 09, 11);
            var buyerId = _buyerInMemoryStorage.AddBuyer(name);
            var ticketId = _ticketInMemoryStorage.AddTicket(from, to, dateTime);

            var purchase = _purchaseInMemoryStorage.AddPurchase(buyerId, ticketId);

            var expectedResult = 0;

            //act
            _purchaseInMemoryStorage.RemovePurchase(purchase);
            var actualGames = _purchaseInMemoryStorage.GetAllPurchases();

            //assert
            Assert.AreEqual(expectedResult, actualGames.Count);
        }
    }
}
